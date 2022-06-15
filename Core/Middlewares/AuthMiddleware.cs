using AllAboutGames.Services;

namespace AllAboutGames.Core.Middlewares
{
    public class AuthMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            var jwt = token.Split()[1];
            var decoded = AuthService.DecodeJwtTokent(jwt);
            //if (token != null)
            //{
            //    var jwtToken = string.Empty;
            //    var tokenSplit = token.Split();
            //    if(tokenSplit.Length == 1)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        jwtToken = tokenSplit[1];
            //    }

            //    var userID = AuthService.DecodeJwtTokent(jwtToken);
            //}

            await next(context);
        }
    }
}
