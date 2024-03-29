﻿using AllAboutGames.Core.CustomMapper;
using AutoMapper;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Data.MappingInterfaces
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes().ToList();
            foreach (var map in GetFromMaps(types))
            {
                this.CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            var fromMaps = from t in types
                           from i in t.GetTypeInfo().GetInterfaces()
                           where i.GetTypeInfo().IsGenericType &&
                                 i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                 !t.GetTypeInfo().IsAbstract &&
                                 !t.GetTypeInfo().IsInterface
                           select new TypesMap
                           {
                               Source = i.GetTypeInfo().GetGenericArguments()[0],
                               Destination = t,
                           };

            return fromMaps;
        }
    }

    public class TypesMap
    {
        public Type Source { get; set; }

        public Type Destination { get; set; }
    }
}
