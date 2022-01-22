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
    public class LikeFilter<TEntity> : IFilter<TEntity, string>
    {
        public string Name { get; init; }
        public string PropertyName { get; init; }


        private string _value { get; set; }
        public string Value { get => _value; init => _value = value; }


        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query)
        {
            if (String.IsNullOrEmpty(_value))
                return query;

            var whereStatementExpresion = getExpression<TEntity>(PropertyName, Value);

            query = query.Where(whereStatementExpresion);

            return query;
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


        private Expression<Func<TEntity, bool>> getExpression<TEntity>(string fieldName, string value)
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

                var parameter = Expression.Parameter(typeof(TEntity));



                var methods = typeof(string).GetMethods();


                MethodInfo contains = methods.FirstOrDefault(x => x.Name == "Contains");


                var body = Expression.Call(Expression.Property(parameter, prop.Name), contains, Expression.Constant(fieldValue, prop.PropertyType));

                return Expression.Lambda<Func<TEntity, bool>>(body, parameter);


            }

            return null;
        }
    }
}
