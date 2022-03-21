using AllAboutGames.Core.Attributes;
using AllAboutGames.Data.Models;
using AllAboutGames.Services;

namespace AllAboutGames.Handlers
{
    public class LoginHandler
    {
        private readonly UserService UserService;

        public LoginHandler(UserService userService)
        {
            this.UserService = userService;
        }

        [BindRequest(typeof(LoginRequest), typeof(LoginResponse))]
        public async Task<LoginResponse> Login(LoginRequest req)
        {
            //var user = await this.UserService.GetEntityAsync<ApplicationUser>(x => x.Username == req.Username && x.Password == req.Password);
            var jwt = AuthService.GenerateJwtToken(666);
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
