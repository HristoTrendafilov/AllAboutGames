using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
#nullable disable

namespace AllAboutGames.Services
{
    public class UserService : BaseService
    {
        public UserService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }

        public ApplicationUser GetUser(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return this.GetUsers(predicate).FirstOrDefault();
        }

        public List<ApplicationUser> GetUsers(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return this.Db.ApplicationUsers
                .Include(x => x.Country)
                .Include(x => x.UsersRoles)
                .ThenInclude(x => x.Role)
                .Where(predicate)
                .ToList();
        }

        public List<Role> GetRoles(Expression<Func<Role, bool>> predicate)
        {
            return this.Db.Roles
                .Where(predicate)
                .ToList();
        }

        public List<Country> GetCountries(Expression<Func<Country, bool>> predicate)
        {
            return this.Db.Countries
                .Where(predicate)
                .ToList();
        }
    }
}
