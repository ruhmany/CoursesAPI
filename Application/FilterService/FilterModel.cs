namespace RahmanyCourses.Application.FilterService
{
    public class FilterModel<T>
    {
        public List<FilterExpression<T>> FilterExpressions { get; set; }
    }
}

