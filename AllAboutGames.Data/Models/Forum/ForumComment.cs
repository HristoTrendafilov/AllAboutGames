using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumComment
    {
        [Key]
        public int ForumCommentID { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(ForumPost))]
        public int ForumPostID { get; set; }

        public ForumPost ForumPost { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public ApplicationUser User { get; set; }
    }
}
