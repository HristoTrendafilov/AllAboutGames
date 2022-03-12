using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AutoMapper;

namespace AllAboutGames.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Game, GameViewModel>().ReverseMap();
            this.CreateMap<Developer, DeveloperViewModel>().ReverseMap();
        }
    }
}
