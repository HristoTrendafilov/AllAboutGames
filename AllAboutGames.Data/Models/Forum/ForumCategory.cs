using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumCategory
    {
        [Key]
        public long ForumCategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(200, ErrorMessage = "The category name must be maximum 200 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category description is required.")]
        public string Description { get; set; }

        public string? Image { get; set; }

        public virtual List<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();
    }
}
