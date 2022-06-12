using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DTO;
using AllAboutGames.Services;
using AutoMapper;

namespace AllAboutGames.Handlers
{
    public class CountryHandler
    {
        private readonly CountryService CountryService;
        private readonly IMapper Mapper;

        public CountryHandler(CountryService countryService, IMapper mapper)
        {
            this.CountryService = countryService;
            this.Mapper = mapper;
        }

        [BindRequest(typeof(GetAllCountriesRequest), typeof(GetAllCountriesResponse))]
        public GetAllCountriesResponse GetAllCountries(GetAllCountriesRequest req)
        {
            var countries = this.CountryService.GetAllCountries(x => true);

            var countriesDto = this.Mapper.Map(countries, new List<CountryDTO>());
            return new GetAllCountriesResponse() { Countries = countriesDto };
        }
    }

    public class GetAllCountriesResponse
    {
        public List<CountryDTO> Countries { get; set; }
    }

    public class GetAllCountriesRequest
    {
    }
}
