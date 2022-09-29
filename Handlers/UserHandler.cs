using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares;
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
        public GatewayResult Login(LoginUserRequest req, AuthResult authResult)
        {
            Thread.Sleep(2000);
            var user = this.UserService.GetUser(x => x.Username == req.Username && x.Password == req.Password);
            if (user == null)
            {
                return GatewayResult.FromErrorMessage("The username or password are incorect.");
            }

            var response = new LoginUserResponse();
            var jwt = this.AuthService.GenerateJwtToken(user.UserID);
            response.UserDTO = this.Mapper.Map<UserDTO>(user);
            response.UserDTO.Roles = this.Mapper.Map<List<RoleDTO>>(user.UsersRoles.Select(x => x.Role));
            response.UserDTO.Jwt = jwt;

            return GatewayResult.SuccessfulResult(response);
        }

        [BindRequest(typeof(RegisterUserRequest), typeof(RegisterUserResponse))]
        public async Task<GatewayResult> Register(RegisterUserRequest request)
        {
            var dbUser = this.UserService.GetUser(x => x.Username == request.UserDTO.Username);
            if (dbUser != null)
            {
                return GatewayResult.FromErrorMessage($"There already exist user with username: {request.UserDTO.Username}");
            }

            var saveCheck = await this.UserService.SaveEntityAsync<ApplicationUser>(request.UserDTO);
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

        [BindRequest(typeof(GetUsersRequest), typeof(GetUsersResponse))]
        public GatewayResult GetUsers(GetUsersRequest request)
        {
            var users = this.UserService.GetUsers(x => true);
            if (users == null || users.Count == 0)
            {
                return GatewayResult.FromErrorMessage("No users found.");
            }

            var usersDto = this.Mapper.Map(users, new List<UserDTO>());
            return GatewayResult.SuccessfulResult(new GetUsersResponse { UsersDTO = usersDto});
        }

        [BindRequest(typeof(AddUserRolesRequest), typeof(AddUserRolesResponse))]
        public async Task<GatewayResult> AddUserRoles(AddUserRolesRequest request)
        {
            var userRoles = this.UserService.GetUserRoles(x => x.UserID == request.UserID);
            var rolesToAdd = request.Roles.Where(p => !userRoles.Any(l => p == l.RoleID)).ToList();
            if (rolesToAdd.Count == 0)
            {
                return GatewayResult.FromErrorMessage("The user already has the selected roles.");
            }

            foreach (var roleID in rolesToAdd)
            {
                var userRole = new ApplicationUserRole
                {
                    UserID = request.UserID,
                    RoleID = roleID
                };

                await this.UserService.SaveEntityAsync<ApplicationUserRole>(userRole);
            }

            await this.UserService.SaveChangesAsync();
            return GatewayResult.SuccessfulResult();
        }

        [BindRequest(typeof(DeleteUserRolesRequest), typeof(DeleteUserRolesResponse))]
        public async Task<GatewayResult> DeleteUserRoles(DeleteUserRolesRequest request)
        {
            var userRoles = this.UserService.GetUserRoles(x => x.UserID == request.UserID);
            var rolesToDelete = request.Roles.Where(p => userRoles.Any(l => p == l.RoleID)).ToList();
            if (rolesToDelete.Count == 0)
            {
                return GatewayResult.FromErrorMessage("The user doesn't have any of the selected roles to delete.");
            }

            foreach (var roleID in rolesToDelete)
            {
                this.UserService.DeleteUserRole(request.UserID, roleID);
            }

            await this.UserService.SaveChangesAsync();
            return GatewayResult.SuccessfulResult();
        }

        [BindRequest(typeof(GetRolesRequest), typeof(GetRolesResponse))]
        public GetRolesResponse GetRoles(GetRolesRequest req)
        {
            var predicate = PredicateBuilder.True<Role>();
            if (req.UserID > 0)
            {
                predicate = predicate.And(x => x.UsersRoles.Any(x => x.UserID == req.UserID));
            }

            var roles = this.UserService.GetRoles(predicate);
            var rolesDTO = this.Mapper.Map(roles, new List<RoleDTO>());

            return new GetRolesResponse { RolesDTO = rolesDTO };
        }

        [BindRequest(typeof(GetCountriesRequest), typeof(GetCountriesResponse))]
        public GetCountriesResponse GetCountries(GetCountriesRequest req)
        {
            var countries = this.UserService.GetCountries(x => true);

            var countriesDto = this.Mapper.Map(countries, new List<CountryDTO>());
            return new GetCountriesResponse() { Countries = countriesDto };
        }

        [BindRequest(typeof(SaveCountryRequest), typeof(SaveCountryResponse))]
        public async Task<GatewayResult> SaveCountry(SaveCountryRequest req)
        {
            var country = this.UserService.GetCountries(x => x.Name == req.CountryDTO.Name).FirstOrDefault();
            if (country != null)
            {
                return GatewayResult.FromErrorMessage($"Country: {country.Name} already exists.");
            }

            await this.UserService.SaveEntityAsync<Country>(req.CountryDTO);
            await this.UserService.SaveChangesAsync();

            return GatewayResult.SuccessfulResult();
        }
    }

    public class DeleteUserRolesRequest
    {
        public long UserID { get; set; }

        public List<long> Roles { get; set; }
    }

    public class DeleteUserRolesResponse
    {
    }

    public class AddUserRolesRequest
    {
        public long UserID { get; set; }

        public List<long> Roles { get; set; }
    }

    public class AddUserRolesResponse
    {
    }

    public class SaveCountryRequest
    {
        public CountryDTO CountryDTO { get; set; }
    }

    public class SaveCountryResponse
    {
    }

    public class GetCountriesResponse
    {
        public List<CountryDTO> Countries { get; set; }
    }

    public class GetCountriesRequest
    {
    }

    public class GetRolesRequest
    {
        public int UserID { get; set; }
    }

    public class GetRolesResponse
    {
        public List<RoleDTO> RolesDTO { get; set; }
    }

    public class GetUsersRequest
    {
    }

    public class GetUsersResponse
    {
        public List<UserDTO> UsersDTO { get; set; }
    }

    public class LoginUserRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginUserResponse
    {
        public UserDTO UserDTO { get; set; }
    }

    public class RegisterUserRequest
    {
        public UserDTO UserDTO { get; set; }
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

    public class LogoutUserRequest
    {
    }

    public class LogoutUserResponse
    {
    }
}
