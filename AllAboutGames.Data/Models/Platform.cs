using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Platform
    {
        public Platform()
        {
            this.GamesPlatforms = new List<GamePlatform>();
        }

        [Key]
        public int PlatformID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Info { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Developer))]
        public int DeveloperID { get; set; }

        public Developer Developer { get; set; }

        public virtual List<GamePlatform> GamesPlatforms { get; set; }
    }
}
