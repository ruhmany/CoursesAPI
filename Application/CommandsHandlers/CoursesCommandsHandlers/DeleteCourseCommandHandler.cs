using MediatR;
using RahmanyCourses.Application.Commands.CourseCommands;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.CommandsHandlers.CoursesCommandsHandlers
{
    internal class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseResult>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitofwork;
        public DeleteCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitofwork)
        {
            _courseRepository = courseRepository;
            _unitofwork = unitofwork;
        }

        public async Task<DeleteCourseResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.CourseID);
            if(course is null)
                return new DeleteCourseResult { IsFound = false };
            if (course.InstructorID != request.UserID)
                return new DeleteCourseResult { IsFound = true, IsUserAuthorized = false };
            _courseRepository.Delete(course);
            _unitofwork.CommitChanges();
            return new DeleteCourseResult { Title = course.Title, IsFound = true, IsUserAuthorized = true };
        }
    }
}
