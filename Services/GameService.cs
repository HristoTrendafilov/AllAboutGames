using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;

namespace AllAboutGames.Services
{
    public class GameService
    {
        private readonly AllAboutGamesDataContext Db;

        public GameService(AllAboutGamesDataContext db)
        {
            this.Db = db;
        }

        public void SaveGame(Genre game)
        {
            this.Db.Add(game);
            this.Db.SaveChanges();
        }
    }
}
