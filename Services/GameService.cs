using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
#nullable disable

namespace AllAboutGames.Services
{
    public class GameService : BaseService
    {
        public GameService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }

        public Game GetGame(Expression<Func<Game, bool>> predicate)
        {
            return this.Db.Games
                .Include(x => x.Developer)
                .Where(predicate)
                .FirstOrDefault();
        }
    }
}
