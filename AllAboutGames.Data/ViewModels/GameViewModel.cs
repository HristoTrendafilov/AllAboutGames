using AllAboutGames.Core.CustomMapper;
using AllAboutGames.Data.Models;

namespace AllAboutGames.Data.ViewModels
{
    public class GameViewModel : IMapFrom<Game>
    {
        public int GameID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Summary { get; set; }

        public string Image { get; set; }

        public string? Website { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? RatingsCount { get; set; }

        public string? TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DeveloperViewModel Developer { get; set; }
    }
}
