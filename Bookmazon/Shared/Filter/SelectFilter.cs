using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public class SelectFilter<TValues> : IFilter
    {

        private ICollection<TValues> values;

        public ICollection<TValues> Values {  init => values = value; }
        public string PropertyName { get; init; }

        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
        {

            if (typeof(TValues) == typeof(T).GetProperty(PropertyName).PropertyType)
                return query.Where(x => values.Contains((TValues)x.GetType().GetProperty(PropertyName).GetValue(x)));

            return query;
        }

        public void FromQueryString(string queryString)
        {
            NameValueCollection queryStringCollection = System.Web.HttpUtility.ParseQueryString(string.Empty);


            var valuesAsString = queryStringCollection.Get(PropertyName);

            if (valuesAsString == null)
                return;

            values = (ICollection<TValues>)valuesAsString
                .Split(",")
                .Select(s => {
                    try
                    {
                        return Convert.ChangeType(s, typeof(T));
                    } catch  (Exception ex){
                        return null;
                    }
                })
                .Where(w => w != null)
                .ToList();
        }

        public string ToQueryString()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);


            queryString.Add(PropertyName, String.Join(",", values));

            return queryString.ToString();
        }
    }
}
