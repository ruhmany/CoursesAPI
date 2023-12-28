using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.FilterService
{
    public class GenericFilter<T>
    {
        /// <summary>
        /// Applies filters to the given query.
        /// </summary>
        /// <param name="query">The IQueryable to filter.</param>
        /// <param name="filters">The filter model containing filter expressions.</param>
        /// <returns>The filtered IQueryable.</returns>
        public IQueryable<T> ApplyFilter(IQueryable<T> query, FilterModel<T> filters)
        {
            if (filters is null)
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var predicate = BuildPredicate(parameter, filters);

            return predicate != null ? query.Where(predicate) : query;
        }

        private Expression GetRightExpression(object value, Type targetType)
        {
            switch (Type.GetTypeCode(targetType))
            {
                case TypeCode.String:
                    return Expression.Constant(value?.ToString(), targetType);
                case TypeCode.Decimal:
                    return Expression.Constant(decimal.Parse(value?.ToString() ?? "0"), targetType);
                case TypeCode.Int32:
                    return Expression.Constant(int.Parse(value?.ToString() ?? "0"), targetType);
                // Add other cases as needed
                default:
                    return null;
            }
        }

        private BinaryExpression BuildBinaryExpression(Expression left, Expression right, ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return Expression.Equal(left, right);
                case ComparisonOperator.GreaterThan:
                    return Expression.GreaterThan(left, right);
                case ComparisonOperator.LessThan:
                    return Expression.LessThan(left, right);
                // We can add other cases as needed
                default:
                    throw new NotSupportedException($"Comparison operator '{comparisonOperator}' is not supported.");
            }
        }

        private Expression<Func<T, bool>> BuildPredicate(ParameterExpression parameter, FilterModel<T> filters)
        {
            Expression finalExpression = null;

            foreach (var filter in filters.FilterExpressions)
            {
                var propertyInfo = typeof(T).GetProperty(filter.PropertyName);
                if (propertyInfo is null)
                {
                    continue; // Skip filters with unknown properties
                }

                var left = Expression.Property(parameter, propertyInfo);
                var right = GetRightExpression(filter.Value, propertyInfo.PropertyType);

                if (right != null)
                {
                    var equality = BuildBinaryExpression(left, right, filter.Operator);
                    finalExpression = finalExpression == null
                        ? equality
                        : Expression.AndAlso(finalExpression, equality);
                }
            }

            return finalExpression != null ? Expression.Lambda<Func<T, bool>>(finalExpression, parameter) : null;
        }
    }

    public class FilterModel<T>
    {
        public List<FilterExpression<T>> FilterExpressions { get; set; }
    }

    public class FilterExpression<T>
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public ComparisonOperator Operator { get; set; } = ComparisonOperator.Equal;
    }

    public enum ComparisonOperator
    {
        Equal,
        GreaterThan,
        LessThan,
        // we can dd other operators as needed
    }

}
