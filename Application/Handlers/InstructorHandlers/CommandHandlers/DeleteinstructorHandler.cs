using Application.Commands.CourseCommands;
using Application.Commands.InstructorCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.InstructorHandlers.CommandHandlers
{
    public class DeleteinstructorHandler : IRequestHandler<DeleteInstructorCommand, Instructor>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteinstructorHandler(IInstructorRepository instructorRepository, IUnitOfWork unitOfWork)
        {
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Instructor> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.GetInstructorByID(request.Id);
            if (instructor != null)
            {
                _instructorRepository.DeleteInstructor(instructor);
                _unitOfWork.CommitChanges();
            }
            return instructor;
        }
    }
}
