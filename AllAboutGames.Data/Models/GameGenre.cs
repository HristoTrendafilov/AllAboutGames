using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class GameGenre
    {
        [Key]
        public long GameGenreID { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public long GameID { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public long GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
