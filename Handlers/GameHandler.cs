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

        public async Task SaveGameAsync(Game game)
        {
            await this.GameService.SaveGameAsync(game);
        }

        public async Task<GameViewModel> GetGame(int gameID)
        {
            var game = await this.GameService.GetGameAsync(gameID);
            var viewModel = this.Mapper.Map(game, new GameViewModel());

            return viewModel;
        }
    }
}
