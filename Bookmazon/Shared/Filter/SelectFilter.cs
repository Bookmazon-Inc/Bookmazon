using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public class SelectFilter<TEntity, TValues> : IFilter<TEntity, TValues>
    {
        public string Name { get; init; }
        public string PropertyName { get; init; }



        private ICollection<TValues> values;
        public ICollection<TValues> Values {  init => values = value; }



        private ICollection<T> getICollection<T>(ICollection collection)
        {
            return (ICollection<T>)collection;
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query)
        {
            if(values == null || values.Count() == 0)
                return query;


            var a = getExpression<TEntity>(values);
            return query.Where(a);
        }

        public void FromQueryString(string queryString)
        {
            NameValueCollection queryStringCollection = System.Web.HttpUtility.ParseQueryString(queryString);


            var valuesAsString = queryStringCollection.Get(Name);

            if (valuesAsString == null)
                return;

            var x = valuesAsString.Split(",").AsQueryable();

            try
            {
                values = x.Select(s => (TValues)Convert.ChangeType(s, typeof(TValues))).Where(x => x != null).ToList();
            } catch {
                return;
            }

        }

        public string ToQueryString()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);


            queryString.Add(Name, String.Join(",", values));

            return queryString.ToString();
        }

        private Expression<Func<TEntity, bool>> getExpression<TEntity>(ICollection<TValues> values)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(TEntity)).Find(PropertyName, true);

            if (prop != null)
            {

                if (prop.PropertyType == typeof(int))
                {

                    var parameter = Expression.Parameter(typeof(TEntity));

                    var methods = typeof(ICollection<int>).GetMethods();


                    MethodInfo contains = methods.FirstOrDefault(x => x.Name == "Contains");

                    var IdProperty = Expression.Property(parameter, prop.Name);
                    var vakueCollection = Expression.Constant(values);


                    var body = Expression.Call(vakueCollection, contains, IdProperty);

                    return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
                }


            }

            return null;
        }
    }
}
