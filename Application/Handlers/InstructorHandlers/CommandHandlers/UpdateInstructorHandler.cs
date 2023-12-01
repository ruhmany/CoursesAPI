using Application.Commands.InstructorCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Handlers.InstructorHandlers.CommandHandlers
{
    public class UpdateInstructorHandler : IRequestHandler<UpdateInstructorCommand, Instructor>
    {
        private readonly IInstructorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateInstructorHandler(IInstructorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Instructor> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _repository.GetInstructorByID(request.Id);
            if (instructor != null)
            {
                instructor.Username = request.Username;
                instructor.Email = request.Email;
                instructor.Bio = request.Bio;
            }
            _repository.UpdateInstructor(instructor);
            _unitOfWork.CommitChanges();
            return instructor;

        }
    }
}
