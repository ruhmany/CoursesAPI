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
    public class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollmentCommand, Enrollment>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEnrollmentHandler(IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork)
        {
            _enrollmentRepository = enrollmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Enrollment> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentByID(request.Id);
            if(enrollment != null)
            {
                _enrollmentRepository.DeleteEnrollment(enrollment);
                _unitOfWork.CommitChanges();
            }
            return enrollment;
        }
    }
}
