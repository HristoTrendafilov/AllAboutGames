using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using AutoMapper;
#nullable disable

namespace AllAboutGames.Services
{
    public class GameService : BaseService
    {
        public GameService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }
    }
}
