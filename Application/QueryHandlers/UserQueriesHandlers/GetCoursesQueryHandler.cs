using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.UserQueries;
using RahmanyCourses.Core.Interfaces.Repositories;
using MediatR;

namespace RahmanyCourses.Application.QueryHandlers.UserQueriesHandlers
{
    internal class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseReturnModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetCoursesQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<CourseReturnModel>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _userRepository.GetEnrolledInCourses(request.UserId);
            var result = courses.Select(c => new CourseReturnModel 
            { 
                CategoryName = c.Category.CategoryName, 
                Description = c.Description,
                Rating = c.Ratings.Average(r => r.RatingValue),
                StudentsNumber = c.Enrollments.Count(), 
                InstructorName = c.Instructor.UserProfile?.FirstName, 
                Title = c.Title
            });
            return result;
        }
    }
}
