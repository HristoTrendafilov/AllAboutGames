using AllAboutGames.Data.Attributes;
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

        [Required(ErrorMessage = "Game name is required.")]
        [MaxLength(200, ErrorMessage = "The Game name must be maximum 200 characters.")]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Summary is required.")]
        public string Summary { get; set; }

        public string? Image { get; set; }

        [MaxLength(500, ErrorMessage = "The Website must be maximum 500 characters.")]
        public string? Website { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? RatingsCount { get; set; }

        [MaxLength(500, ErrorMessage = "The Thrailer URL must be maximum 500 characters.")]
        public string? TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey(nameof(Developer))]
        public int? DeveloperID { get; set; }

        [IncludeInQuery]
        public virtual Developer Developer { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<Rating> Ratings { get; set; }

        public virtual List<GamePlatform> GamePlatforms { get; set; }

        public virtual List<GameGenre> GameGenres { get; set; }
    }
}
