using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace AllAboutGames.Services
{
    public class GameService
    {
        private readonly AllAboutGamesDataContext Db;

        public GameService(AllAboutGamesDataContext db)
        {
            this.Db = db;
        }

        public async Task SaveGameAsync(Game game)
        {
            await this.Db.AddAsync(game);
            await this.Db.SaveChangesAsync();
        }

        public Task<Game> GetGameAsync(int gameID)
        {
            var game = this.Db.Games
                .Include(x => x.Developer)
                .Where(x => x.GameID == gameID)
                .FirstOrDefaultAsync();

            return game;
        }
    }
}
