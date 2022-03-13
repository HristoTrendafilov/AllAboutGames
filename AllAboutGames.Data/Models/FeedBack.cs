using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackID { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
