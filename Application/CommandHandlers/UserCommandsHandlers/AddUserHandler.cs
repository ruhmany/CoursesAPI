using Application.Commands.UserCommands;
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
    public class AddUserHandler : IRequestHandler<AddUserCommand, User>
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

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            _authService.CreateHashPassword(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            var User = _mapper.Map<User>(request);
            User.PasswordHash = PasswordHash;
            User.PasswordSalt = PasswordSalt;
            User.Token = "";
            User.RegistrationDate = DateTime.Now;
            await _userRepository.Add(User);
            _unitOfWork.CommitChanges();
            User.Token = _authService.CreateToken(User);
            _unitOfWork.CommitChanges();
            return User;
        }
    }
}
