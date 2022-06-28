using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using AutoMapper;
using System.Linq.Expressions;

namespace AllAboutGames.Services
{
    public class RoleService : BaseService
    {
        public RoleService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }

        public List<Role> GetRoles(Expression<Func<Role, bool>> predicate)
        {
            return this.Db.Roles
                .Where(predicate)
                .ToList();
        }
    }
}
