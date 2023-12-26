using RahmanyCourses.Application.Commands.UserProfileCommands;
using RahmanyCourses.Application.Models;
using AutoMapper;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RahmanyCourses.Application.CommandHandlers.UserProfileCommandsHandlers
{
    public class UserProfileCommandsHandlers : IRequestHandler<AddUserProfileCommand, UserProfileReturnModel>
    {
        private readonly IUserRepository _repository;
        private readonly IPhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserProfileCommandsHandlers(IServiceProvider provider)
        {
            _repository = provider.GetRequiredService<IUserRepository>();
            _photoService = provider.GetRequiredService<IPhotoService>();
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _mapper = provider.GetRequiredService<IMapper>();
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
