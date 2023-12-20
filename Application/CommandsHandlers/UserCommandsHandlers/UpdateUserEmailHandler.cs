using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;

namespace RahmanyCourses.Application.CommandHandlers.UserCommandsHandlers
{
    public class UpdateUserEmailHandler : IRequestHandler<UpdateUserEmailCommand, UserReturnModel>
    {        
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserEmailHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<UserReturnModel> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.OldEmail);
            if(user != null)
            {
                user.Email = request.Email;
                _unitOfWork.CommitChanges();
            }
            return new UserReturnModel { Email = user.Email, Username = user.Username };
        }
    }
}
