using MediatR;
using RahmanyCourses.Application.FilterService;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.CourseQueries;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;

namespace RahmanyCourses.Application.QueryHandlers.CourseQueriesHandlers
{
    internal class GetFilteredCoursesQueryHandler : IRequestHandler<GetFilteredCoursesQuery, IEnumerable<CourseReturnModel>>
    {
        private readonly ICourseRepository _repository;
        private readonly GenericFilter<Course> _genericFilter;

        public GetFilteredCoursesQueryHandler(ICourseRepository repository, GenericFilter<Course> genericFilter)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _genericFilter = genericFilter ?? throw new ArgumentNullException(nameof(genericFilter));
        }

        public async Task<IEnumerable<CourseReturnModel>> Handle(GetFilteredCoursesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQueryableData();
            var filteredQuery = _genericFilter.ApplyFilter(query, request.Filters);
            var result = filteredQuery.Select(x => new CourseReturnModel
            {
                Title = x.Title,
                ID = x.ID,
                Price = x.Price,
                Description = x.Description,
                InstructorName = x.Instructor.Username,
                CategoryName = x.Category.CategoryName,
                StudentsNumber = x.Enrollments.Count
            }).ToList();

            return result;
        }
    }
}
