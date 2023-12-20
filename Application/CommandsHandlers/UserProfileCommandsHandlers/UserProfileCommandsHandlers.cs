using RahmanyCourses.Application.Commands.UserProfileCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;

namespace RahmanyCourses.Application.CommandHandlers.UserProfileCommandsHandlers
{
    public class UserProfileCommandsHandlers : IRequestHandler<AddUserProfileCommand, UserProfileReturnModel>
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

        public async Task<UserProfileReturnModel> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
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
            return new UserProfileReturnModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                ProfilePicture = profile.ProfilePicture,
                Bio = profile.Bio
            };
        }
    }
}
