using Application.Commands.UserCommands;
using Application.Models;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.UserCommandsHandlers
{
    public class GetUserTokenHandler : IRequestHandler<GetUserTokenCommand, AuthModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserTokenHandler(IAuthService authService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthModel> Handle(GetUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.UsernameOrEmail);
            if (user == null)
            {
                return null;
            }
            var isPasswordCorrect = _authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (isPasswordCorrect)
            {
                var authModel = new AuthModel();
                authModel.Username = user.Username;
                authModel.UserType = user.UserType;
                authModel.Token = _authService.CreateToken(user);
                if (user.RefreshTokens.Any(rt => rt.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.IsActive);
                    activeRefreshToken.RevokeOn = DateTime.UtcNow;
                }
                var refreshToken = _authService.CreateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiredOn;
                _userRepository.Update(user);
                _unitOfWork.CommitChanges();               
                return authModel;
            }
            return null;
        }
    }
}
