using AllAboutGames.Core.CustomMapper;
using AllAboutGames.Data.Models;
#nullable disable

namespace AllAboutGames.Data.ViewModels
{
    public class DeveloperViewModel : IMapFrom<Developer>
    {
        public int DeveloperID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
