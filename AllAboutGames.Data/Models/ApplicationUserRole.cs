using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllAboutGames.Data.Models
{
    public class ApplicationUserRole
    {
        [Key]
        public long ApplicationUserRoleID { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public long UserID { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Role))]
        public long RoleID { get; set; }
        public Role Role { get; set; }
    }
}
