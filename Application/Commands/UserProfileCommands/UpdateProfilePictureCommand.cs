using Application.Models;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.UserProfileCommands
{
    public class UpdateProfilePictureCommand : IRequest<UserProfileReturnModel>
    {
        public int ProfileID { get; set; }
        public IFormFile ProfilePic { get; set; }

    }
}
