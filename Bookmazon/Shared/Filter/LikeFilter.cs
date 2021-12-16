using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Filter
{
    public class LikeFilter : IFilter
    {
        public string Value { get; init; }
        public string PropertyName { get; init; }

        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
        {
            if(typeof(T).GetProperty(PropertyName) == typeof(string))
            {
                return query.Where(w => ((string)w.GetType().GetProperty(PropertyName).GetValue(w)).Contains(Value));
            }

            return query;
        }

        public void FromQueryString(string queryString)
        {
            throw new NotImplementedException();
        }

        public string ToQueryString()
        {
            throw new NotImplementedException();
        }
    }
}
