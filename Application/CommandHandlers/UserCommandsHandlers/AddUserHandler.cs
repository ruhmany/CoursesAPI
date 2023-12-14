using Application.Commands.UserCommands;
using Application.Models;
using AutoMapper;
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
    public class AddUserHandler : IRequestHandler<AddUserCommand, AuthModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserHandler(IUnitOfWork unitOfWork, IAuthService authService, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var checkuserbyusername = await _userRepository.GetUserByUsername(request.Username);
            var checkuserbyemail = await _userRepository.GetByEmail(request.Email);

            if(checkuserbyemail is not null || checkuserbyusername is not null)
            {
                return null;
            }
            _authService.CreateHashPassword(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            var User = _mapper.Map<User>(request);
            User.PasswordHash = PasswordHash;
            User.PasswordSalt = PasswordSalt;
            User.Token = "";
            User.RegistrationDate = DateTime.Now.ToLocalTime();
            var refreshtoken = _authService.CreateRefreshToken();
            User.RefreshTokens = new List<RefreshToken>
            {
                refreshtoken
            };
            await _userRepository.Add(User);
            _unitOfWork.CommitChanges();
            User.Token = _authService.CreateToken(User);
            _userRepository.Update(User);
            _unitOfWork.CommitChanges();
            var authModel = _mapper.Map<AuthModel>(User);

            authModel.RefreshToken = refreshtoken.Token;
            authModel.RefreshTokenExpiration = refreshtoken.ExpiredOn;
            return authModel;
        }
    }
}
