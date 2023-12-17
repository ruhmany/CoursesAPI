using Application.Helpers;
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
            var rating = CalculateCourseRate.ClacRate(course.Ratings);
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
