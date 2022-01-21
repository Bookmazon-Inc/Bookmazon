using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public static class Extentions
    {
        public static void ApplyFilter<T>(this IQueryable<T> query, FilterGroup<T> filters) where T : class
        {
            filters.ApplyFilter(query);
        }
    }
}
