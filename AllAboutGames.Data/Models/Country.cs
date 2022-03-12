using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Cities = new List<City>();
        }

        [Key]
        public int CountryID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
