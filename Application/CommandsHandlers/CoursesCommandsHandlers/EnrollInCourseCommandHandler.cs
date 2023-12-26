using RahmanyCourses.Application.Commands.CourseCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RahmanyCourses.Application.CommandsHandlers.CoursesCommandsHandlers
{
    internal class EnrollInCourseCommandHandler : IRequestHandler<EnrollInCourseCommand, EnrollmentReturnModel>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EnrollInCourseCommandHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _mapper = provider.GetRequiredService<IMapper>(); ;
            _courseRepository = provider.GetRequiredService<ICourseRepository>(); ;
        }

        public async Task<EnrollmentReturnModel> Handle(EnrollInCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.CourseID);
            if (course == null)
                return new EnrollmentReturnModel { IsCourseAvailable = false};
            if(course.InstructorID == request.StudentID)
                return new EnrollmentReturnModel { IsUserAllowedToEnroll = false, IsCourseAvailable = true };
            var enrollment = new Enrollment
            {
                CourseID = request.CourseID,
                UserID = request.StudentID,
                EnrollmentDate = DateTime.UtcNow
            };
            course.Enrollments.Add(enrollment);
            _courseRepository.Update(course);
            _unitOfWork.CommitChanges();
            return new EnrollmentReturnModel { IsCourseAvailable = true, 
                IsUserAllowedToEnroll = true, 
                CourseID = request.CourseID, 
                StudentID = request.StudentID };
        }
    }
}
