using RahmanyCourses.Application.Commands.UserCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RahmanyCourses.Application.CommandHandlers.UserCommandsHandlers
{
    public class CreateNewTokensHandler : IRequestHandler<CreateNewTokensCommand, AuthModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateNewTokensHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _authService = provider.GetRequiredService<IAuthService>();
            _userRepository = provider.GetRequiredService<IUserRepository>();
            _mapper = provider.GetRequiredService<IMapper>();
        }

        public async Task<AuthModel> Handle(CreateNewTokensCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);
            if(user == null)
            {
                return null;    
            }
            var rt = user.RefreshTokens.FirstOrDefault(rt => rt.Token == request.RefreshToken);
            if(rt == null || !rt.IsValid)
            {
                return null;
            }
            rt.RevokeOn = DateTime.UtcNow;
            var token = _authService.CreateToken(user);
            var refreshtoken = _authService.CreateRefreshToken();
            user.Token = token;
            user.RefreshTokens.Add(refreshtoken);
            _userRepository.Update(user);
            _unitOfWork.CommitChanges();
            var auth = _mapper.Map<AuthModel>(user);
            auth.RefreshToken = refreshtoken.Token;
            auth.RefreshTokenExpiration = refreshtoken.ExpiredOn;
            return auth;
        }
    }
}
