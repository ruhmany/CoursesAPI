using Application.Commands.UserProfileCommands;
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

namespace Application.CommandHandlers.UserProfileCommandsHandlers
{
    public class UserProfileCommandsHandlers : IRequestHandler<AddUserProfileCommand, UserProfile>
    {
        private readonly IUserRepository _repository;
        private readonly IPhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserProfileCommandsHandlers(IUserRepository repository, IPhotoService photoService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserProfile> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.UserID);
            if (user == null)
            {
                return null;
            }
            var profile = _mapper.Map<UserProfile>(request);
            var result = await _photoService.AddPhotoAsync(request.ProfilePicture);
            profile.ProfilePicture = result.Url.ToString();
            user.UserProfile = profile;
            _repository.Update(user);
            _unitOfWork.CommitChanges();
            throw new NotImplementedException();
        }
    }
}
