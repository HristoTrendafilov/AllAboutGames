using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
using AllAboutGames.Services;
using AutoMapper;

namespace AllAboutGames.Handlers
{
    public class GenreHandler
    {
        private readonly GenreService GenreService;
        private readonly IMapper Mapper;

        public GenreHandler(GenreService genreService, IMapper mapper)
        {
            this.GenreService = genreService;
            this.Mapper = mapper;
        }

        [BindRequest(typeof(GetGenresRequest), typeof(GetGenresResponse))]
        public GetGenresResponse GetGenres(GetGenresRequest req)
        {
            var genres = this.GenreService.GetGenres(x => true);
            var genresDto = this.Mapper.Map(genres, new List<GenreDTO>());
            
            return new GetGenresResponse { GenresDTO = genresDto };
        }

        [BindRequest(typeof(SaveGenreRequest), typeof(SaveGenreResponse))]
        public async Task<GatewayResult> SaveGenre(SaveGenreRequest req)
        {
            var genre = this.GenreService.GetGenres(x => x.Name == req.GenreDTO.Name).FirstOrDefault();
            if(genre != null)
            {
                return GatewayResult.FromErrorMessage($"Genre: {genre.Name} already exists.");
            }

            await this.GenreService.SaveEntityAsync<Genre>(req.GenreDTO);
            await this.GenreService.SaveChangesAsync();

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
}
