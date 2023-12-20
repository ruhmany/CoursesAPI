using MediatR;
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

        public UpdateProfilePictureCommandHandler(IUnitOfWork unitOfWork, IPhotoService photoService, IUserProfileRepository repository)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _repository = repository;
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
