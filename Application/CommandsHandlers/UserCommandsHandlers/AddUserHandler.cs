using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RahmanyCourses.Application.CommandHandlers.UserCommandsHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, AuthModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _authService = provider.GetRequiredService<IAuthService>();
            _userRepository = provider.GetRequiredService<IUserRepository>();
            _mapper = provider.GetRequiredService<IMapper>();
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
