using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumCategory
    {
        public ForumCategory()
        {
            this.ForumPosts = new List<ForumPost>();
        }

        [Key]
        public int ForumCategoryID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual List<ForumPost> ForumPosts { get; set; }
    }
}
