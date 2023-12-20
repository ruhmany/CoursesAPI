using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;

namespace RahmanyCourses.Application.CommandHandlers.UserCommandsHandlers
{
    public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, UserReturnModel>
    {
        private readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitofwork;
        private readonly IAuthService _authService;

        public UpdateUserPasswordHandler(IAuthService authService, IUnitOfWork unitofwork, IUserRepository userRepository)
        {
            _authService = authService;
            _unitofwork = unitofwork;
            _userRepository = userRepository;
        }

        public async Task<UserReturnModel> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.ID);
            var isoldpasswordvirified = _authService.VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt);
            if (isoldpasswordvirified)
            {
                _authService.CreateHashPassword(request.NewPassword, out byte[] NewPasswordHash, out byte[] NewPasswordSalt);
                user.PasswordHash = NewPasswordHash;
                user.PasswordSalt = NewPasswordSalt;
                _userRepository.Update(user);
                _unitofwork.CommitChanges();
            }
            return new UserReturnModel { Email = user.Email, Username = user.Username };
        }
    }
}
