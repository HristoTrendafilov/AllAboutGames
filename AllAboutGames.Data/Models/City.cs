using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllAboutGames.Data.Models
{
    public class City
    {
        public City()
        {
            this.Users = new List<ApplicationUser>();
        }

        [Key]
        public int CityID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }
    }
}
