using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.UserQueries;
using RahmanyCourses.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.QueryHandlers.UserQueriesHandlers
{
    internal class GetCreatedCoursesCommandHandler : IRequestHandler<GetCreatedCoursesCommand, IEnumerable<CourseReturnModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetCreatedCoursesCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<CourseReturnModel>> Handle(GetCreatedCoursesCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            if (user == null)
                return null;
            var result = user.Courses.Select(c => new CourseReturnModel { Title = c.Title, Description = c.Description, 
                                        CategoryName = c.Category.CategoryName, InstructorName = c.Instructor.Username, StudentsNumber = c.Enrollments.Count }).ToList();
            return result;
        }
    }
}
