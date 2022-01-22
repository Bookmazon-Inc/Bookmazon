using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Filter
{
    public interface IBaseFilter<TEntity>
    {
        public string Name { get; init; }
        public string PropertyName { get; init; }
        public string ToQueryString();
        public void FromQueryString(string queryString);
        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query);
    }
}
