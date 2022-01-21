using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookmazon.Shared.Filter
{
    //public class LikeFilter : IFilter
    //{
    //    private string _value { get; set; }
    //    public string Value { get => _value; init => _value = value; }
    //    public string PropertyName { get; init; }

    //    public IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
    //    {
    //        if (String.IsNullOrEmpty(_value))
    //            return query;


    //        if (typeof(T).GetProperty(PropertyName).PropertyType == typeof(string))
    //        {
    //            return query.Where(w => ((string)w.GetType().GetProperty(PropertyName).GetValue(w)).Contains(Value));
    //        }

    //        return query;
    //    }


    //    public void FromQueryString(string queryString)
    //    {
    //        NameValueCollection queryStringCol = System.Web.HttpUtility.ParseQueryString(queryString);

    //        _value = queryStringCol.Get(PropertyName);
    //    }

    //    public string ToQueryString()
    //    {
    //        NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

    //        queryString.Add(PropertyName, Value);

    //        return queryString.ToString();
    //    }
    //}

    public class LikeFilter<TEntity> : IFilter<TEntity, string>
    {
        public string Name { get; init; }
        public Func<TEntity, string> GetPropertyValue { get; init; }


        private string _value { get; set; }
        public string Value { get => _value; init => _value = value; }

        public void ApplyFilter(IQueryable<TEntity> query)
        {
            if (String.IsNullOrEmpty(_value))
                return;

            query = query.Where(w => GetPropertyValue(w).Contains(Value));


            var e = GetCriteriaPredicate<string>(nameof("Title"), "TEST");

            var x = query.ToArray();
            var y = x;
        }


        public void FromQueryString(string queryString)
        {
            NameValueCollection queryStringCol = System.Web.HttpUtility.ParseQueryString(queryString);

            _value = queryStringCol.Get(Name);
        }

        public string ToQueryString()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(Name, Value);

            return queryString.ToString();
        }




        private Expression<Func<T, bool>> GetCriteriaPredicate<T>(string fieldName, string value)
        {

            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(TEntity)).Find(fieldName, true);

            if (prop != null)
            {
                //value as object
                object fieldValue = null;

                //String
                if (prop.PropertyType == typeof(string))
                {
                    fieldValue = value;
                }

                var parameter = Expression.Parameter(typeof(T));


                        
                MethodInfo contains = typeof(string).GetMethod("Contains");

                var body = Expression.Call(Expression.Property(parameter, prop.Name), contains, Expression.Constant(fieldValue, prop.PropertyType));

                return Expression.Lambda<Func<T, bool>>(body, parameter);

                
            }

            return null;
        }


    }
}
