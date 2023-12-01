using Application.Commands.EnrollmentCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.EnrollmentHandlers.CommandsHandlers
{
    public class AddEnrollmentHnadler : IRequestHandler<AddEnrollmentCommand, Enrollment>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddEnrollmentHnadler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
        {
            _enrollmentRepository = enrollmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Enrollment> Handle(AddEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollment = new Enrollment
            {
                EnrollAt = DateTime.Now,
                StudentID = request.StudentID,
                CourseID = request.CourseID,
            };
            await _enrollmentRepository.AddEnrollment(enrollment);
            _unitOfWork.CommitChanges();
            return enrollment;
        }
    }
}
