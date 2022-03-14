using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Rating value is required.")]
        public int Value { get; set; }
    }
}
