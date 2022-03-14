using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumComment
    {
        [Key]
        public long ForumCommentID { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(ForumPost))]
        public long ForumPostID { get; set; }

        public ForumPost ForumPost { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long UserID { get; set; }

        public ApplicationUser User { get; set; }
    }
}
