using Application.Commands.CourseCommands;
using Application.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsHandlers.CoursesCommandsHandlers
{
    internal class EnrollInCourseCommandHandler : IRequestHandler<EnrollInCourseCommand, EnrollmentReturnModel>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EnrollInCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICourseRepository courseRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseRepository = courseRepository;
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
