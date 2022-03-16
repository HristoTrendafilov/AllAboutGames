using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Country
    {
        [Key]
        public long CountryID { get; set; }

        [Required(ErrorMessage = "Country name is required.")]
        [MaxLength(100, ErrorMessage = "The country name must be maximum 100 characters.")]
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; } = new List<City>();
    }
}
