using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using AutoMapper;

namespace AllAboutGames.Handlers
{
    public class GameHandler
    {
        private readonly GameService GameService;
        private readonly IMapper Mapper;

        public GameHandler(GameService gameService, IMapper mapper)
        {
            this.GameService = gameService;
            this.Mapper = mapper;
        }

        public void SaveGame(Game game)
        {
            this.GameService.SaveGame(game);
        }

        public GameViewModel GetGame(int gameID)
        {
            var game = this.GameService.GetGame(gameID);
            var viewModel = Mapper.Map(game, new GameViewModel());

            return viewModel;
        }
    }
}
