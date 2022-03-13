using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models.Forum
{
    public class ForumLike
    {
        [Key]
        public int ForumLikeID { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(ForumPost))]
        public int ForumPostID { get; set; }

        public ForumPost ForumPost { get; set; }
    }
}
