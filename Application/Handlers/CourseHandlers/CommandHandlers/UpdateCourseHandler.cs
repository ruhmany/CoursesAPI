using Application.Commands.CourseCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CourseHandlers.CommandHandlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, Course>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Course> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetCourseById(request.Id);
            
            if(course != null)
            {
                course.Title = request.Title;
                course.Description = request.Description;
                course.EnrollmentCapacity = request.EnrollmentCapacity;
                course.StartDate = request.StartDate;
                course.EndDate = request.EndDate;
                _courseRepository.UpdateCourse(course);
                _unitOfWork.CommitChanges();
            }
            return course;

        }
    }
}
