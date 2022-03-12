using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AllAboutGames.Services
{
    public class GameService
    {
        private readonly AllAboutGamesDataContext Db;

        public GameService(AllAboutGamesDataContext db)
        {
            this.Db = db;
        }

        public void SaveGame(Game game)
        {
            this.Db.Add(game);
            this.Db.SaveChanges();
        }

        public Game GetGame(int gameID)
        {
            var game = this.Db.Games
                .Include(x => x.Developer)
                .Where(x => x.GameID == gameID)
                .FirstOrDefault();
            return game;
        }
    }
}
