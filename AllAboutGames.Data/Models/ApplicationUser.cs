using AllAboutGames.Data.Models.Forum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllAboutGames.Data.Models
{
    public class ApplicationUser
    {
        [Key]
        public long UserID { get; set; }
        
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(100, ErrorMessage = "The username must be maximum 100 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(100, ErrorMessage = "The password must be maximum 100 characters.")]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey(nameof(Country))]
        public long CountryID { get; set; }

        public Country Country { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        public virtual List<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();

        public virtual List<ForumComment> ForumComments { get; set; } = new List<ForumComment>();

        public virtual List<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

        public virtual List<ApplicationUserRole> UsersRoles { get; set; } = new List<ApplicationUserRole>();
    }
}
