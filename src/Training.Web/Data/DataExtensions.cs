using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.Web.Data
{
    public static class DataExtensions
    {
        public static IEnumerable<T> Order<T>(this IEnumerable<T> personen,
                                              Func<T, object> selector,
                                              string direction)
        {
            return direction == "asc"
                       ? personen.OrderBy(selector)
                       : personen.OrderByDescending(selector);
        }
    }
}