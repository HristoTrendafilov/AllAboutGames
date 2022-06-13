using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using AutoMapper;
using System.Linq.Expressions;

namespace AllAboutGames.Services
{
    public class CountryService : BaseService
    {
        public CountryService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }

        public List<Country> GetCountries(Expression<Func<Country, bool>> predicate)
        {
            return this.Db.Countries
                .Where(predicate)
                .ToList();
        }
    }
}
