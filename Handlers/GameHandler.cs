using AllAboutGames.Core;
using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using AutoMapper;
using Newtonsoft.Json;
using Serilog;
#nullable disable

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

        public async Task<CheckResult> SaveGameAsync(Game game)
        {
            var checkResult = PropertyValidator.Validate(game);
            if (checkResult.IsFailed)
            {
                Log.Fatal("ERORS: ", checkResult.GetErrors());
                return checkResult;
            }

            var DbGame = await this.GameService.GetEntityAsync<Game>(x => x.GameID == game.GameID);
            if (DbGame == null)
            {
                await this.GameService.SaveGameAsync(game);
            }

            return checkResult;
        }

        public async Task<GameViewModel> GetGame(int gameID)
        {
            var game = await this.GameService.GetEntityAsync<Game>(x => x.GameID == gameID);
            return game == null ? null : this.Mapper.Map(game, new GameViewModel());
        }
    }
}
