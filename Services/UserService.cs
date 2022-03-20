using AllAboutGames.Data.DataContext;
using AutoMapper;

namespace AllAboutGames.Services
{
    public class UserService : BaseService
    {
        public UserService(AllAboutGamesDataContext db, IMapper mapper) : base(db, mapper) { }
    }
}
