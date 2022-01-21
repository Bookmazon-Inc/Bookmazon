using Bookmazon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public abstract class FilterGroup<TEntity>
    {
        private ICollection<IBaseFilter<TEntity>> filters = new List<IBaseFilter<TEntity>>();

        protected void AddFilter(IBaseFilter<TEntity> filter) => filters.Add(filter);


        public void ApplyFilter(IQueryable<TEntity> query)
        {
            foreach (var filter in filters)
                filter.ApplyFilter(query);
        }
        public void FromQueryString(string queryString)
        {
            foreach (var filter in filters)
                filter.FromQueryString(queryString);
        }

    }
}
