using AllAboutGames.Core.CustomMapper;
using AllAboutGames.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Data.DTO
{
    public class GenreDTO : IMapFrom<Genre>
    {
        public long GenreID { get; set; }

        [Required(ErrorMessage = "Genre name is required.")]
        [MaxLength(100, ErrorMessage = "The Genre name must be maximum 100 characters.")]
        public string Name { get; set; }
    }
}
