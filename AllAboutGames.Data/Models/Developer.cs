using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Developer
    {
        [Key]
        public long DeveloperID { get; set; }

        [Required(ErrorMessage = "Developer name is required.")]
        [MaxLength(200, ErrorMessage = "The Developer name must be maximum 200 characters.")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
