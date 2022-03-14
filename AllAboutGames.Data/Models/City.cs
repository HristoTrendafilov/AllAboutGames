using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(100, ErrorMessage = "The city name must be maximum 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country name is required.")]
        [ForeignKey(nameof(Country))]
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public virtual List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
