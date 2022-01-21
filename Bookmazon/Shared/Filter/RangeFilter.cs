using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace  Bookmazon.Shared.Filter
{
    public class RangeFilter<TEntity> : IFilter<TEntity, int>
    {
        private int? max;
        public int Max { init => max = value; }

        private int? min;
        public int Min { init => min = value; }

        public Func<TEntity, int> GetPropertyValue { get; init; }
        public string Name { get; init; }

        public IQueryable<T> ApplyFilter<T>(IQueryable<T> query)
        {
            return query.Where(w => isInRange(w));
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

        private bool isInRange<T>(T type)
        {
            var prop = type.GetType().GetProperty(Name);


            if (prop == null || !isNumericType(prop.PropertyType))
                return true;
            
            if(min != null && max != null)
                return Convert.ToInt32(prop.GetValue(type)) >= min && Convert.ToInt32(prop.GetValue(type)) <= max;

            if (min != null)
                return Convert.ToInt32(prop.GetValue(type)) >= min;

            if (max != null)
                return Convert.ToInt32(prop.GetValue(type)) <= max;



            return true;
        }


        private bool isNumericType(Type o)
        {
            var x = Type.GetTypeCode(o);

            switch (x)
            {
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public void ApplyFilter(IQueryable<TEntity> query)
        {
            throw new NotImplementedException();
        }
    }
}
