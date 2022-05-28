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
            return this.Db.ApplicationUsers
                .Include(x => x.City)
                .Where(predicate)
                .FirstOrDefault();
        }
    }
}
