using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
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

        [BindRequest(typeof(SaveCountryRequest), typeof(SaveCountryResponse))]
        public async Task<GatewayResult> SaveCountry(SaveCountryRequest req)
        {
            var country = this.CountryService.GetCountries(x => x.Name == req.CountryDTO.Name).FirstOrDefault();
            if (country != null)
            {
                return GatewayResult.FromErrorMessage($"Country: {country.Name} already exists.");
            }

            await this.CountryService.SaveEntityAsync<Country>(req.CountryDTO);
            await this.CountryService.SaveChangesAsync();

            return GatewayResult.SuccessfulResult();
        }
    }

    public class SaveCountryRequest
    {
        public CountryDTO CountryDTO { get; set; }
    }

    public class SaveCountryResponse
    {

    }

    public class GetCountriesResponse
    {
        public List<CountryDTO> Countries { get; set; }
    }

    public class GetCountriesRequest
    {
    }
}
