namespace RahmanyCourses.Application.FilterService
{
    public class FilterExpression<T>
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public ComparisonOperator Operator { get; set; } = ComparisonOperator.Equal;
    }
}

