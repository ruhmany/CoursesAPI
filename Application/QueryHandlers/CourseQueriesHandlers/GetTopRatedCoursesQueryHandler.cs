using Application.Models;
using Application.Queries.CourseQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandlers.CourseQueriesHandlers
{
    internal class GetTopRatedCoursesQueryHandler : IRequestHandler<GetTopRatedCoursesQuery, IEnumerable<CourseReturnModel>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetTopRatedCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseReturnModel>> Handle(GetTopRatedCoursesQuery request, CancellationToken cancellationToken)
        {
            var toRatedCourses = await _courseRepository.GetTopRatedCourses();
            var result = toRatedCourses.Select(c => new CourseReturnModel
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
