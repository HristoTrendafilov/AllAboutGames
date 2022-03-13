using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            this.GamesGenres = new List<GameGenre>();
        }

        [Key]
        public int GenreID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual List<GameGenre> GamesGenres { get; set; }
    }
}
