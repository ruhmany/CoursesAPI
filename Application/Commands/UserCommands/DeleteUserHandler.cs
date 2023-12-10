using Application.CommandHandlers.UserCommandsHandlers;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Commands.UserCommands
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if(user != null) 
            {
                _userRepository.Delete(user);
                _unitOfWork.CommitChanges();
            }
        }
    }
}
