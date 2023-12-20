using RahmanyCourses.Application.Commands.CourseCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.CommandHandlers.CoursesCommandsHandlers
{
    public class AddCourseHandler : IRequestHandler<AddCourseCommand, CourseReturnModel>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseReturnModel> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            course.CreationDate = DateTime.UtcNow;
            await _courseRepository.Add(course);
            _unitOfWork.CommitChanges();
            return new CourseReturnModel { Title = course.Title, Description = course.Description,
                                            InstructorName = course.Instructor.UserProfile.FirstName,
                                             CategoryName = course.Category.CategoryName }; 
        }
    }
}
