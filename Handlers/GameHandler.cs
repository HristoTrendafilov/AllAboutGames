using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using AutoMapper;
using Serilog;

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
            Log.Information("XAXAAXAXA");
            throw new Exception("aidee");

            var game = await this.GameService.GetGameAsync(gameID);
            var viewModel = this.Mapper.Map(game, new GameViewModel());

            return viewModel;
        }
    }
}
