using AllAboutGames.Data.Models.Forum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            this.Ratings = new List<Rating>();
            this.Reviews = new List<Review>();
            this.ForumPosts = new List<ForumPost>();
            this.FeedBacks = new List<FeedBack>();
        }

        [Key]
        public long ApplicationUserID { get; set; }
        
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

        [Required(ErrorMessage = "City is required.")]
        [ForeignKey(nameof(City))]
        public int CityID { get; set; }

        public City City { get; set; }

        public virtual List<Rating> Ratings { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<ForumPost> ForumPosts { get; set; }

        public virtual List<ForumComment> ForumComments { get; set; }

        public virtual List<FeedBack> FeedBacks { get; set; }
    }
}
