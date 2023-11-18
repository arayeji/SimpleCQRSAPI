using FlightBookingAPI.Domain.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace FlightBookingAPI.Repositories
{
    public static class LinqExtensions
    {
        public static IQueryable<T> BuildDynamicQuery<T>(IQueryable<T> query, List<Expression<Func<T, bool>>> filters = null, PaginationParameters paginationParameters = null)
        {
            if (filters != null)
            {
                foreach (var filter in filters)
                    query = query.Where(filter);
            }

            if (paginationParameters.Pagination)
            {
                query = query.Skip(paginationParameters.SkipCalculation());

                if (paginationParameters.PageSize.HasValue)
                {
                    query = query.Take(paginationParameters.PageSize.Value);
                }

                if (paginationParameters.SortBy != null)
                {
                    if (paginationParameters.SortDescending.HasValue && paginationParameters.SortDescending.Value)
                    {
                        query = query.OrderByDescending(paginationParameters.SortBy);
                    }
                    else
                    {
                        query = query.OrderBy(paginationParameters.SortBy);
                    }
                }
            }

            return query;
        }

        public static IOrderedQueryable<T> OrderBy<T>(
    this IQueryable<T> source,
    string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(
            this IQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }

        public static IOrderedQueryable<T> ThenBy<T>(
            this IOrderedQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(
            this IOrderedQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }

        static IOrderedQueryable<T> ApplyOrder<T>(
            IQueryable<T> source,
            string property,
            string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}
