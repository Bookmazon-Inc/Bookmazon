using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Filter
{
    public class LikeFilter : IFilter
    {
        private string _value { get; set; }
        public string Value { get => _value; init => _value = value; }
        public string PropertyName { get; init; }

        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
        {
            if (String.IsNullOrEmpty(_value))
                return query;


            if (typeof(T).GetProperty(PropertyName).PropertyType == typeof(string))
            {
                return query.Where(w => ((string)w.GetType().GetProperty(PropertyName).GetValue(w)).Contains(Value));
            }

            return query;
        }


        public void FromQueryString(string queryString)
        {
            NameValueCollection queryStringCol = System.Web.HttpUtility.ParseQueryString(queryString);

            _value = queryStringCol.Get(PropertyName);
        }

        public string ToQueryString()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(PropertyName, Value);

            return queryString.ToString();
        }
    }
}
