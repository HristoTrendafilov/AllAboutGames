using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
using AllAboutGames.Services;
using AutoMapper;
using System.Linq.Expressions;

namespace AllAboutGames.Handlers
{
    public class RoleHandlers
    {
        private readonly RoleService RoleService;
        private readonly IMapper Mapper;

        public RoleHandlers(RoleService roleService, IMapper mapper)
        {
            this.RoleService = roleService;
            this.Mapper = mapper;
        }

        [BindRequest(typeof(GetRolesRequest), typeof(GetRolesResponse))]
        public GetRolesResponse GetRoles(GetRolesRequest req)
        {
            var predicate = PredicateBuilder.True<Role>();
            if(req.UserID > 0)
            {
                predicate = predicate.And(x => x.UsersRoles.Any(x => x.UserID == req.UserID));
            }

            var roles = this.RoleService.GetRoles(predicate);
            var rolesDTO = this.Mapper.Map(roles, new List<RoleDTO>());

            return new GetRolesResponse { RolesDTO = rolesDTO };
        }
    }

    public class GetRolesRequest
    {
        public int UserID { get; set; }
    }

    public class GetRolesResponse
    {
        public List<RoleDTO> RolesDTO { get; set; }
    }
}
