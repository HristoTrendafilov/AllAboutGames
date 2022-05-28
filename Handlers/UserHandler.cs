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

        [BindRequest(typeof(LoginRequest), typeof(LoginResponse))]
        public GatewayResult Login(LoginRequest req)
        {
            var user = this.UserService.GetUser(x => x.Username == req.Username && x.Password == req.Password);
            if (user == null)
            {
                return GatewayResult.FromErrorMessage("The username or password are incorect.");
            }

            var jwt = AuthService.GenerateJwtToken(user.UserID);
            return GatewayResult.SuccessfulResult(new LoginResponse() { Jwt = jwt });
        }

        [BindRequest(typeof(RegisterRequest), typeof(RegisterResponse))]
        public async Task<GatewayResult> Register(RegisterRequest request)
        {
            var checkResult = PropertyValidator.Validate(request.UserDTO);
            if (checkResult.IsFailed)
            {
                return GatewayResult.FromErrorMessage(checkResult.GetErrors());
            }

            var saveCheck = await this.UserService.SaveEntityAsync<ApplicationUser>(request.UserDTO);
            if (saveCheck.IsFailed)
            {
                return GatewayResult.FromErrorMessage(saveCheck.GetErrors());
            }

            await this.UserService.SaveChangesAsync();

            return GatewayResult.SuccessfulResult(new RegisterRequest());
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

    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Jwt { get; set; }
    }

    public class RegisterRequest
    {
        public UserDTO UserDTO { get; set; }
    }

    public class RegisterResponse
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
