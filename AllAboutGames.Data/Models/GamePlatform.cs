using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class GamePlatform
    {
        [Key]
        public long GamePlatformID { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public long GameID { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Platform))]
        public long PlatformID { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
