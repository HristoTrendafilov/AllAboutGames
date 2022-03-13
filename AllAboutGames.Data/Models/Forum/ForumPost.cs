using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumPost
    {
        public ForumPost()
        {
            this.ForumComments = new List<ForumComment>();
            this.ForumLikes = new List<ForumLike>();
        }

        [Key]
        public int ForumPostID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(ForumCategory))]
        public int ForumCategoryID { get; set; }

        public ForumCategory ForumCategory { get; set; }

        public virtual List<ForumComment> ForumComments { get; set; }

        public virtual List<ForumLike> ForumLikes { get; set; }
    }
}
