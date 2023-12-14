using Application.Commands.UserCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.CommandHandlers.UserCommandsHandlers
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if (user != null)
            {
                _userRepository.Delete(user);
                _unitOfWork.CommitChanges();
            }
            return user;
        }
    }
}
