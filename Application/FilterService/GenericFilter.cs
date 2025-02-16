using System.Linq.Expressions;

namespace RahmanyCourses.Application.FilterService
{
    public class GenericFilter<T>
    {
        public IQueryable<T> ApplyFilter(IQueryable<T> query, FilterModel<T> filters)
        {
            if (filters is null)
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var predicate = BuildPredicate(parameter, filters);

            return predicate != null ? query.Where(predicate) : query;
        }

        private Expression GetRightExpression(object value, Type targetType)
        {
            return Type.GetTypeCode(targetType) switch
            {
                TypeCode.String => Expression.Constant(value?.ToString(), targetType),
                TypeCode.Decimal => Expression.Constant(decimal.Parse(value?.ToString() ?? "0"), targetType),
                TypeCode.Int32 => Expression.Constant(int.Parse(value?.ToString() ?? "0"), targetType),
                _ => null
            };
        }

        private BinaryExpression BuildBinaryExpression(Expression left, Expression right, ComparisonOperator comparisonOperator)
        {
            return comparisonOperator switch
            {
                ComparisonOperator.Equal => Expression.Equal(left, right),
                ComparisonOperator.GreaterThan => Expression.GreaterThan(left, right),
                ComparisonOperator.LessThan => Expression.LessThan(left, right),
                _ => throw new NotSupportedException($"Comparison operator ‘{comparisonOperator}’ is not supported.")
            };
        }

        private Expression<Func<T, bool>> BuildPredicate(ParameterExpression parameter, FilterModel<T> filters)
        {
            Expression finalExpression = null;

            foreach (var filter in filters.FilterExpressions)
            {
                var propertyInfo = typeof(T).GetProperty(filter.PropertyName);
                if (propertyInfo is null)
                    continue;

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
}

