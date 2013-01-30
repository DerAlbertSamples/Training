using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Training.Web.Extensions
{
    public static class MappingHelper
    {
        public static IEnumerable<TDestination> MapFrom<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }

        public static TDestination MapTo<TDestination>(this object source) where TDestination : class
        {
            if (source == null)
                return default(TDestination);
            return Mapper.Map<TDestination>(source);
        }

        public static void MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }

        public static TDestination[] ToArray<TDestination>(this IProjectionExpression expression)
        {
            return expression.To<TDestination>().ToArray();
        }


        public static IProjectionExpression Project<TSource>(this IQueryable<TSource> source)
        {
            return source.Project(Mapper.Engine);
        }
    }
}