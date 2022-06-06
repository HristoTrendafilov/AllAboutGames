using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
using AllAboutGames.Services;
using AutoMapper;

namespace AllAboutGames.Handlers
{
    public class UserHandler
    {
        private readonly UserService UserService;
        private readonly AuthService AuthService;
        private readonly IMapper Mapper;

        public UserHandler(UserService userService, AuthService authService, IMapper mapper)
        {
            this.UserService = userService;
            this.AuthService = authService;
            this.Mapper = mapper;
        }

        [BindRequest(typeof(LoginUserRequest), typeof(LoginUserResponse))]
        public GatewayResult Login(LoginUserRequest req)
        {
            var user = this.UserService.GetUser(x => x.Username == req.Username && x.Password == req.Password);
            if (user == null)
            {
                return GatewayResult.FromErrorMessage("The username or password are incorect.");
            }

            var jwt = AuthService.GenerateJwtToken(user.UserID);
            return GatewayResult.SuccessfulResult(new LoginUserResponse() { Jwt = jwt });
        }

        [BindRequest(typeof(RegisterUserRequest), typeof(RegisterUserResponse))]
        public async Task<GatewayResult> Register(RegisterUserRequest request)
        {
            var checkResult = PropertyValidator.Validate(request.Item);
            if (checkResult.IsFailed)
            {
                return GatewayResult.FromErrorMessage(checkResult.GetErrors());
            }

            var dbUser = this.UserService.GetUser(x => x.Username == request.Item.Username);
            if (dbUser != null)
            {
                return GatewayResult.FromErrorMessage($"There already exist user with username: {request.Item.Username}");
            }

            var saveCheck = await this.UserService.SaveEntityAsync<ApplicationUser>(request.Item);
            await this.UserService.SaveChangesAsync();

            return GatewayResult.SuccessfulResult(new RegisterUserRequest());
        }

        [BindRequest(typeof(GetUserRequest), typeof(GetUserResponse))]
        public GatewayResult GetUser(GetUserRequest request)
        {
            var user = this.UserService.GetUser(x => x.UserID == request.UserID);
            if (user == null)
            {
                return GatewayResult.FromErrorMessage("The user doest not exist.");
            }

            var userDto = this.Mapper.Map(user, new UserDTO());
            return GatewayResult.SuccessfulResult(userDto);
        }
    }

    public class LoginUserRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginUserResponse
    {
        public string Jwt { get; set; }
    }

    public class RegisterUserRequest
    {
        public UserDTO Item { get; set; }
    }

    public class RegisterUserResponse
    {

    }

    public class GetUserRequest
    {
        public long UserID { get; set; }
    }

    public class GetUserResponse
    {
        public UserDTO UserDTO { get; set; }
    }
}
