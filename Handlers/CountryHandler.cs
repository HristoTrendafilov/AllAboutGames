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

        [BindRequest(typeof(GetCountriesRequest), typeof(GetCountriesResponse))]
        public GetCountriesResponse GetCountries(GetCountriesRequest req)
        {
            var countries = this.CountryService.GetCountries(x => true);

            var countriesDto = this.Mapper.Map(countries, new List<CountryDTO>());
            return new GetCountriesResponse() { Countries = countriesDto };
        }
    }

    public class GetCountriesResponse
    {
        public List<CountryDTO> Countries { get; set; }
    }

    public class GetCountriesRequest
    {
    }
}
