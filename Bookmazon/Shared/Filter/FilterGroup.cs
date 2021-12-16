using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public abstract class FilterGroup
    {
        private ICollection<IFilter> filters = new List<IFilter>();

        protected void AddFilter(IFilter filter) => filters.Add(filter);


        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query) where T : class
        {
            foreach (var filter in filters)
                query = filter.ApplyFilter(query);

            return query;
        }
        public void FromQueryString(string queryString)
        {
            foreach (var filter in filters)
                filter.FromQueryString(queryString);
        }

    }
}
