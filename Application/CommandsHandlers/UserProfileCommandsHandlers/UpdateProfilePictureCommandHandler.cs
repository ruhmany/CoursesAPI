﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RahmanyCourses.Application.Commands.UserProfileCommands;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Interfaces.Repositories;
using RahmanyCourses.Core.Interfaces.Services;
using RahmanyCourses.Core.Interfaces.UnitOfWork;

namespace RahmanyCourses.Application.CommandsHandlers.UserProfileCommandsHandlers
{
    public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommand, UserProfileReturnModel>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IPhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProfilePictureCommandHandler(IServiceProvider provider)
        {
            _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            _photoService = provider.GetRequiredService<IPhotoService>();
            _repository = provider.GetRequiredService<IUserProfileRepository>();
        }

        public async Task<UserProfileReturnModel> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetById(request.ProfileID);
            if (profile == null)
                return null;
            await _photoService.DeletionPhotoAsync(profile.ProfilePicture);
            var result = await _photoService.AddPhotoAsync(request.ProfilePic);
            profile.ProfilePicture = result.Uri.ToString();
            _repository.Update(profile);
            _unitOfWork.CommitChanges();
            return new UserProfileReturnModel { FirstName = profile.FirstName, LastName = profile.LastName,
                                                ProfilePicture = profile.ProfilePicture, Bio = profile.Bio};
        }
    }
}
