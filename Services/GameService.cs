using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace AllAboutGames.Services
{
    public class GameService : BaseService
    {
        public GameService(AllAboutGamesDataContext db) : base(db) { }

        public async Task SaveGameAsync(Game game)
        {
            await this.Db.AddAsync(game);
            await this.Db.SaveChangesAsync();
        }
    }
}
