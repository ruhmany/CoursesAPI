using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace RahmanyCourses.Application.Commands.UserProfileCommands
{
    public class UpdateProfilePictureCommand : IRequest<UserProfileReturnModel>
    {
        public int ProfileID { get; set; }
        public IFormFile ProfilePic { get; set; }

    }
}
