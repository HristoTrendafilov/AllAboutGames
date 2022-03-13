using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class GameGenre
    {
        [Key]
        public int GameGenreID { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreID { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
