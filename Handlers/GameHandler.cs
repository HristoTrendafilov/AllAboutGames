using AllAboutGames.Data.Models;
using AllAboutGames.Services;

namespace AllAboutGames.Handlers
{
    public class GameHandler
    {
        private readonly GameService GameService;

        public GameHandler(GameService gameService)
        {
            this.GameService = gameService;
        }

        public void SaveGame(Genre game)
        {
            this.GameService.SaveGame(game);
        }
    }
}
