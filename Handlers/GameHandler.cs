using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using AutoMapper;
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

        [BindRequest(typeof(SaveGameRequest))]
        public async Task<GatewayResult> SaveGameAsync(SaveGameRequest request)
        {
            var checkResult = PropertyValidator.Validate(request.GameDTO);
            if (checkResult.IsFailed)
            {
                return GatewayResult.FromErrorMessage(checkResult.GetErrors());
            }

            await this.GameService.SaveEntityAsync<Game>(request.GameDTO);
            await this.GameService.SaveChangesAsync();

            return GatewayResult.SuccessfullResult();
        }

        public async Task<GameViewModel> GetGame(int gameID)
        {
            var game = await this.GameService.GetEntityAsync<Game>(x => x.GameID == gameID);
            return game == null ? null : this.Mapper.Map(game, new GameViewModel());
        }
    }

    public class SaveGameRequest
    {
        public GameDTO GameDTO { get; set; }
    }
}
