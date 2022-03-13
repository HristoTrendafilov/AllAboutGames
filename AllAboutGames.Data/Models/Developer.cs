using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Developer
    {
        public Developer()
        {
            this.Games = new List<Game>();
        }

        [Key]
        public int DeveloperID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
