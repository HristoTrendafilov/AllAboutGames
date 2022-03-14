using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackID { get; set; }

        [Required(ErrorMessage = "About information is required.")]
        public string About { get; set; }

        [Required(ErrorMessage = "The text field is required.")]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long UserID { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
