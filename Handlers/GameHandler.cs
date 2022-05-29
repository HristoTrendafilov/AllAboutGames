using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Services;
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

            var saveCheck = await this.GameService.SaveEntityAsync<Game>(request.GameDTO);
            if (saveCheck.IsFailed)
            {
                return GatewayResult.FromErrorMessage(saveCheck.GetErrors());
            }

            await this.GameService.SaveChangesAsync();

            return GatewayResult.SuccessfulResult();
        }

        public GatewayResult GetGame(int gameID)
        {
            var game = this.GameService.GetGame(x => x.GameID == gameID);
            if(game == null)
            {
                return GatewayResult.FromErrorMessage("The game doest not exist.");
            }

            var viewModel = this.Mapper.Map(game, new GameViewModel());
            return GatewayResult.SuccessfulResult(viewModel);
        }
    }

    public class SaveGameRequest
    {
        public GameDTO GameDTO { get; set; }
    }
}
