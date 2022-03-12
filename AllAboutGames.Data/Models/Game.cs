using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllAboutGames.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.GamePlatforms = new List<GamePlatform>();
            this.GameGenres = new List<GameGenre>();
            this.Reviews = new List<Review>();
            this.Ratings = new List<Rating>();
        }

        [Key]
        public int GameID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Image { get; set; }

        public string Website { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int RatingsCount { get; set; }

        public string TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Developer))]
        public int DeveloperID { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<Rating> Ratings { get; set; }

        public virtual List<GamePlatform> GamePlatforms { get; set; }

        public virtual List<GameGenre> GameGenres { get; set; }
    }
}
