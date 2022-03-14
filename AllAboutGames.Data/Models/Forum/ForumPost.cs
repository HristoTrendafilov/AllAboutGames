using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumPost
    {
        [Key]
        public long ForumPostID { get; set; }

        [Required(ErrorMessage = "Post title is required.")]
        [MaxLength(200, ErrorMessage = "The post title must be maximum 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Post content is required.")]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(ForumCategory))]
        public long ForumCategoryID { get; set; }

        public ForumCategory ForumCategory { get; set; }

        public virtual List<ForumComment> ForumComments { get; set; } = new List<ForumComment>();

        public virtual List<ForumLike> ForumLikes { get; set; } = new List<ForumLike>();
    }
}
