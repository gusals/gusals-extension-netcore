using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gusals.Extensions
{
    /// <summary>
    /// Queryable 확장 클래스.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Queryable 정렬.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">Queryable.</param>
        /// <param name="keySelectors">정렬 키.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> OrderBy<T>(
            this IQueryable<T> queryable,
            IEnumerable<(string Property, bool Ascending)> keySelectors)
        {
            var expression = queryable.Expression;
            var count = 0;
            foreach (var (Property, Ascending) in keySelectors)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, Property);
                var method = Ascending
                    ? (count == 0 ? "OrderBy" : "ThenBy")
                    : (count == 0 ? "OrderByDescending" : "ThenByDescending");
                expression = Expression.Call(
                    typeof(Queryable),
                    method,
                    new Type[] { queryable.ElementType, selector.Type },
                    expression,
                    Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? queryable.Provider.CreateQuery<T>(expression) : queryable;
        }
    }
}