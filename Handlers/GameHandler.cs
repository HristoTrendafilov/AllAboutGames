using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
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

            return GatewayResult.SuccessfulResult();
        }

        public GatewayResult GetGame(int gameID)
        {
            var game = this.GameService.GetGame(x => x.GameID == gameID);
            if(game == null)
            {
                return GatewayResult.FromErrorMessage("The game doest not exist.");
            }

            var viewModel = this.Mapper.Map(game, new GameDTO());
            return GatewayResult.SuccessfulResult(viewModel);
        }

        [BindRequest(typeof(GetGenresRequest), typeof(GetGenresResponse))]
        public GetGenresResponse GetGenres(GetGenresRequest req)
        {
            var genres = this.GameService.GetGenres(x => true);
            var genresDto = this.Mapper.Map(genres, new List<GenreDTO>());

            return new GetGenresResponse { GenresDTO = genresDto };
        }

        [BindRequest(typeof(SaveGenreRequest), typeof(SaveGenreResponse))]
        public async Task<GatewayResult> SaveGenre(SaveGenreRequest req)
        {
            var genre = this.GameService.GetGenres(x => x.Name == req.GenreDTO.Name).FirstOrDefault();
            if (genre != null)
            {
                return GatewayResult.FromErrorMessage($"Genre: {genre.Name} already exists.");
            }

            await this.GameService.SaveEntityAsync<Genre>(req.GenreDTO);
            await this.GameService.SaveChangesAsync();

            return GatewayResult.SuccessfulResult();
        }
    }

    public class SaveGenreRequest
    {
        public GenreDTO GenreDTO { get; set; }
    }

    public class SaveGenreResponse
    {
    }

    public class GetGenresRequest
    {
    }

    public class GetGenresResponse
    {
        public List<GenreDTO> GenresDTO { get; set; }
    }

    public class SaveGameRequest
    {
        public GameDTO GameDTO { get; set; }
    }
}
