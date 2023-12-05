using Application.Commands.InstructorCommands;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Handlers.InstructorHandlers.CommandHandlers
{
    public class AddInstructorHandler : IRequestHandler<AddInstructorCommand, Instructor>
    {
        private readonly IInstructorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public AddInstructorHandler(IInstructorRepository repository, IUnitOfWork unitOfWork, IAuthService authService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }


        async Task<Instructor> IRequestHandler<AddInstructorCommand, Instructor>.Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            _authService.CreateHashPassword(request.Password, out byte[] passwordhash, out byte[] PasswordSalt);
            var instructor = new Instructor
            {
                Username = request.Username,
                Email = request.Email,
                Bio = request.Bio,
                PasswordHash = passwordhash,
                PasswordSalt = PasswordSalt,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserType = UserType.Instructor,
                Token = ""
            };

            await _repository.AddInstructor(instructor);
            _unitOfWork.CommitChanges();            
            instructor.Token = _authService.CreateToken(instructor);
            _unitOfWork.CommitChanges();
            return instructor;
        }
    }
}
