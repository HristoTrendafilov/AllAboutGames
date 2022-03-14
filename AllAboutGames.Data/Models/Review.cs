using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Review text is required.")]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(ReviewedBy))]
        public int UserID { get; set; }

        public virtual ApplicationUser ReviewedBy { get; set; }

        [Required]
        [ForeignKey(nameof(Rating))]
        public int RatingID { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
