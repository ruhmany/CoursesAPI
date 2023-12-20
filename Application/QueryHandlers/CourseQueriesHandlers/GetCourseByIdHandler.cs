using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.CourseQueries;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.QueryHandlers.CourseQueriesHandlers
{
    internal class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseReturnModel>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseReturnModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.Id);
            if (course == null)
                return null;
            var rating = course.Ratings.Average(r => r.RatingValue);
            return new CourseReturnModel
            {
                Title = course.Title,
                Description = course.Description,
                InstructorName = course.Instructor.UserProfile?.FirstName,
                CategoryName = course.Category.CategoryName,
                Rating = rating
            };
        }
    }
}
