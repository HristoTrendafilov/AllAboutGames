using AllAboutGames.Core.Attributes;
using AllAboutGames.Data.Models;
using AllAboutGames.Services;

namespace AllAboutGames.Handlers
{
    public class LoginHandler
    {
        private readonly UserService UserService;
        private readonly AuthService AuthService;

        public LoginHandler(UserService userService, AuthService authService)
        {
            this.UserService = userService;
            this.AuthService = authService;
        }

        [BindRequest(typeof(LoginRequest), typeof(LoginResponse))]
        public async Task<LoginResponse> Login(LoginRequest req)
        {
            var user = await this.UserService.GetEntityAsync<ApplicationUser>(x => x.Username == req.Username && x.Password == req.Password);
            var jwt = this.AuthService.GenerateJwtToken(user.UserID);
            return new LoginResponse()
            {
                Jwt = jwt
            };
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Jwt { get; set; }
    }
}
