using AllAboutGames.Data.DataContext;

namespace AllAboutGames.Handlers
{
    public class HelloHandler
    {
        private readonly AllAboutGamesDataContext db;

        public HelloHandler(AllAboutGamesDataContext db)
        {
            this.db = db;
        }

        public string SayHello()
        {
            var game = this.db.Genres.FirstOrDefault();
            return game.Name;
        }
    }
}
