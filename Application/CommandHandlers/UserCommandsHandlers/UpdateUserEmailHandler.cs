using Application.Commands.UserCommands;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using MediatR;

namespace Application.CommandHandlers.UserCommandsHandlers
{
    public class UpdateUserEmailHandler : IRequestHandler<UpdateUserEmailCommand, User>
    {        
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserEmailHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.OldEmail);
            if(user != null)
            {
                user.Email = request.Email;
                _unitOfWork.CommitChanges();
            }
            return user;
        }
    }
}
