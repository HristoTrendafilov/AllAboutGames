using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.Models
{
    public class Role
    {
        [Key]
        public long RoleID { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [MaxLength(100, ErrorMessage = "The Role name must be maximum 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valid from is required.")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Valid to is required.")]
        public DateTime ValidTo { get; set; }

        public virtual List<ApplicationUserRole> UsersRoles { get; set; } = new List<ApplicationUserRole>();
    }
}
