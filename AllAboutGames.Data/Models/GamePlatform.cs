using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class GamePlatform
    {
        [Key]
        public int GamePlatformID { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Platform))]
        public int PlatformID { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
