using AllAboutGames.Core.CustomMapper;
using AllAboutGames.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.DTO
{
    public class CountryDTO : IMapFrom<Country>
    {
        public long CountryID { get; set; }

        [Required(ErrorMessage = "Country name is required.")]
        [MaxLength(100, ErrorMessage = "The country name must be maximum 100 characters.")]
        public string Name { get; set; }

        public string Iso { get; set; }

        public string? Iso3 { get; set; }
    }
}
