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
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, Course>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Course> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetCourseById(request.Id);
            if (course != null)
            {                
                _courseRepository.DeleteCourse(course);
                _unitOfWork.CommitChanges();
            }
            return course;
        }
    }
}
