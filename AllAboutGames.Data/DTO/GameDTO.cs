using AllAboutGames.Core.CustomMapper;
using AllAboutGames.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.DTO
{
    public class GameDTO : IMapFrom<Game>
    {
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

        [MaxLength(500, ErrorMessage = "The Thrailer URL must be maximum 500 characters.")]
        public string? TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? DeveloperID { get; set; }

        public virtual List<int> Reviews { get; set; } = new List<int>();

        public virtual List<int> Ratings { get; set; } = new List<int>();

        public virtual List<int> GamePlatforms { get; set; } = new List<int>();

        public virtual List<int> GameGenres { get; set; } = new List<int>();
    }
}
