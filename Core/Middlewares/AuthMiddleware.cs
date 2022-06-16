using AllAboutGames.Data.Models;
using AllAboutGames.Services;
using Serilog;
#nullable disable

namespace AllAboutGames.Core.Middlewares
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly UserService UserService;
        private readonly AuthService AuthService;

        public AuthMiddleware(UserService userService, AuthService authService)
        {
            this.UserService = userService;
            this.AuthService = authService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var jwt = context.Request.Headers["Authorization"].FirstOrDefault();
            var authResult = Authenticate(jwt);
            context.SetRequestAuth(authResult);

            await next(context);
        }

        private AuthResult Authenticate(string jwt)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(jwt))
                {
                    return new AuthResult(AuthType.None);
                }

                var parts = jwt.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    Log.Information($"Authorization token doesnt consist of two parts. Token: {jwt}");
                    return new AuthResult(AuthType.None);
                }

                string scheme = parts[0];
                string token = parts[1].Trim('"');

                if (string.IsNullOrWhiteSpace(scheme) || string.IsNullOrWhiteSpace(token))
                {
                    Log.Information("Invalid authorization header: missing scheme or token.");
                    return new AuthResult(AuthType.None);
                }

                if (scheme.ToLower() == "jwt")
                {
                    var userID = this.AuthService.DecodeJwtTokent(token);
                    var user = this.UserService.GetUser(x => x.UserID == userID);
                    if (user == null)
                    {
                        return new AuthResult(AuthType.None);
                    }

                    return new AuthResult(AuthType.Jwt, user);
                }

                Log.Information("Invalid authorization header: unsupported scheme.");
                return new AuthResult(AuthType.None);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while authenticating user");
                return new AuthResult(AuthType.None);
            }
        }
    }

    public class AuthResult
    {
        public AuthResult(AuthType type)
        {
            this.Type = type;
        }

        public AuthResult(AuthType type, ApplicationUser user)
        {
            this.Type = type;
            this.User = user;
        }

        public AuthType Type { get; }

        public ApplicationUser User { get; }
    }

    public enum AuthType
    {
        None = 0,
        Jwt = 1,
    }

    public static class RequestExtensions
    {
        private const string AuthData = "AuthData";

        public static AuthResult GetRequestAuth(this HttpContext ctx)
        {
            return (AuthResult)ctx.Items[AuthData];
        }

        public static void SetRequestAuth(this HttpContext ctx, AuthResult authResult)
        {
            ctx.Items[AuthData] = authResult;
        }
    }
}
