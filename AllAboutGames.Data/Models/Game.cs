using AllAboutGames.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllAboutGames.Data.Models
{
    public class Game
    {
        [Key]
        public long GameID { get; set; }

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

        [MaxLength(500, ErrorMessage = "The Thrailer URL must be maximum 500 characters.")]
        public string? TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey(nameof(Developer))]
        public long? DeveloperID { get; set; }

        [IncludeInQuery]
        public virtual Developer Developer { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public virtual List<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();

        public virtual List<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}
