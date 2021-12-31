using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public static class Extentions
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, FilterGroup filters) where T : class
        {
            return filters.ApplyFilter<T>(query);
        }
    }
}
