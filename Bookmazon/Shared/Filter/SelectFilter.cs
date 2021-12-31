using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public class SelectFilter<TValues> : IFilter
    {

        private ICollection<TValues> values;

        public ICollection<TValues> Values {  init => values = value; }
        public string PropertyName { get; init; }
        public string? PropertyKey { get; init; } = null;


        private ICollection<T> getICollection<T>(ICollection collection)
        {
            return (ICollection<T>)collection;
        }

        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
        {
            var propType = typeof(T).GetProperty(PropertyName).PropertyType;
            var genericType = propType.GenericTypeArguments[0];

            if (propType is ICollection && typeof(TValues) == genericType)
            {
                var key = PropertyKey ?? PropertyName + PropertyName.Substring(0, PropertyName.Length - 2) + "Id";

                return query.Where(entity => 
                    ((ICollection<Object>)entity.GetType().GetProperty(PropertyName).GetValue(entity))
                    .AsQueryable<object>()
                    .Where(x => 
                        values.Contains((TValues)x.GetType().GetProperty(key).GetValue(x))
                    ).Any()
                );
            } 
            else if (typeof(TValues) == propType)
            {
                return query.Where(entity => values.Contains((TValues)entity.GetType().GetProperty(PropertyName).GetValue(entity)));
            }

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
                        return Convert.ChangeType(s, typeof(TValues));
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
