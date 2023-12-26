using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.UserQueries;
using RahmanyCourses.Core.Interfaces.Repositories;
using MediatR;
using RahmanyCourses.Application.Queries.CourseQueries;

namespace RahmanyCourses.Application.QueryHandlers.CourseQueriesHandlers
{
    internal class GetEnrolledInCoursesQueryHandler : IRequestHandler<GetEnrolledInCoursesQuery, IEnumerable<CourseReturnModel>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetEnrolledInCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseReturnModel>> Handle(GetEnrolledInCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetEnrolledInCourses(request.UserId);
            var result = courses.Select(c => new CourseReturnModel
            {
                CategoryName = c.Category.CategoryName,
                ID = c.ID,
                Description = c.Description,
                Rating = 9,
                StudentsNumber = 45,
                InstructorName = "Ali",
                Title = c.Title
            });
            return result;
        }
    }
}
