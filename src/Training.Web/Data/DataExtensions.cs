using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Training.Web.Data
{
    public static class DataExtensions
    {
        public static IEnumerable<T> Order<T>(this IEnumerable<T> entities,
                                              Func<T, object> selector,
                                              string direction)
        {
            return direction == "asc"
                       ? entities.OrderBy(selector)
                       : entities.OrderByDescending(selector);
        }

        public static IQueryable<T> Order<T>(this IQueryable<T> entities,
                                      Expression<Func<T, object>> selector,
                                      string direction)
        {
            return direction == "asc"
                       ? entities.OrderBy(selector)
                       : entities.OrderByDescending(selector);
        }
    }
}