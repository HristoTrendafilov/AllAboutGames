using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using AutoMapper;
using System.Linq.Expressions;

namespace AllAboutGames.Services
{
    public class GenreService : BaseService
    {
        public GenreService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }

        public List<Genre> GetGenres(Expression<Func<Genre, bool>> predicate)
        {
            return this.Db.Genres
                .Where(predicate)
                .ToList();
        }
    }
}
