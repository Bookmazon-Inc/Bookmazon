using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public class RangeFilter<TEntity> : IFilter<TEntity, int>
    {
        public string Name { get; init; }
        public string PropertyName { get; init; }


        private int? max;
        public int Max { init => max = value; }


        private int? min;
        public int Min { init => min = value; }



        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query)
        {
            if(min == null && max == null)
                return query;


            if(min != null)
            {
                var greaterThan = getGreaterThanExpression<TEntity>((int)min);

                query = query.Where(greaterThan);
            }

            if (max != null)
            {
                var lessThan = getLessThanExpression<TEntity>(PropertyName, (int)max);

                query = query.Where(lessThan);
            }

            return query;
        }

        public void FromQueryString(string queryString)
        {
            NameValueCollection queryStringCol = System.Web.HttpUtility.ParseQueryString(queryString);

            var values = queryStringCol.Get(Name);

            if(values == null)
            {
                return;
            }
            
            int max = Convert.ToInt32(values.Split(",")[0]);
            int min = Convert.ToInt32(values.Split(",")[1]);

            this.max = max;
            this.min = min;
        }

        public string ToQueryString()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(Name, $"{max},{min}");

            return queryString.ToString();
        }


        private Expression<Func<TEntity, bool>> getGreaterThanExpression<TEntity>(int value)
        {

            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(TEntity)).Find(PropertyName, true);

            if (prop != null)
            {



                ParameterExpression parameter = Expression.Parameter(typeof(TEntity));

                MemberExpression property = Expression.Property(parameter, PropertyName);

                ConstantExpression constant;


                if(prop.PropertyType == typeof(decimal))
                {
                    constant = Expression.Constant((decimal)value, typeof(decimal));
                } else if(prop.PropertyType == typeof(int))
                {
                    constant = Expression.Constant((int)value, typeof(int));
                } else
                {
                    return null;
                }

                BinaryExpression body = Expression.GreaterThan(constant, property);

                var ExpressionTree = Expression.Lambda<Func<TEntity, bool>>(body, new[] { parameter });

                return ExpressionTree;
            }

            return null;
        }

        private Expression<Func<TEntity, bool>> getLessThanExpression<TEntity>(int value)
        {

            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(TEntity)).Find(PropertyName, true);

            if (prop != null)
            {



                ParameterExpression parameter = Expression.Parameter(typeof(TEntity));

                MemberExpression property = Expression.Property(parameter, PropertyName);

                ConstantExpression constant;


                if (prop.PropertyType == typeof(decimal))
                {
                    constant = Expression.Constant((decimal)value, typeof(decimal));
                }
                else if (prop.PropertyType == typeof(int))
                {
                    constant = Expression.Constant((int)value, typeof(int));
                }
                else
                {
                    return null;
                }

                BinaryExpression body = Expression.LessThan(constant, property);

                var ExpressionTree = Expression.Lambda<Func<TEntity, bool>>(body, new[] { parameter });

                return ExpressionTree;
            }

            return null;
        }
    }
}
