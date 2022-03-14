using AutoMapper;

namespace AllAboutGames.Core.CustomMapper
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
