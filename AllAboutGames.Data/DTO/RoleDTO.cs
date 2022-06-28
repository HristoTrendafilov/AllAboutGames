using AllAboutGames.Core.CustomMapper;
using AllAboutGames.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.DTO
{
    public class RoleDTO : IMapFrom<Role>
    {
        public long RoleID { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [MaxLength(100, ErrorMessage = "The Role name must be maximum 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valid from is required.")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Valid to is required.")]
        public DateTime ValidTo { get; set; }

        public long OptionsValue => this.RoleID;

        public string OptionsName => this.Name;
    }
}
