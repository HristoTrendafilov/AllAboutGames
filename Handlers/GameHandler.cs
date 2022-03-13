using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using AutoMapper;
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

        public async Task SaveGameAsync(Game game)
        {
            var DbGame = await this.GameService.GetEntityAsync<Game>(x => x.GameID == game.GameID);
            if (DbGame == null)
            {
                await this.GameService.SaveGameAsync(game);
                return;
            }

            Results.Json(DbGame, null, null, StatusCodes.Status400BadRequest);
        }

        public async Task<GameViewModel> GetGame(int gameID)
        {
            var game = await this.GameService.GetEntityAsync<Game>(x => x.GameID == gameID);
            return game == null ? null : this.Mapper.Map(game, new GameViewModel());
        }
    }
}
