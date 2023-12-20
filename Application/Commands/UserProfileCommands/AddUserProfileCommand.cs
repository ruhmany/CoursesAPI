using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.UserProfileCommands
{
    public class AddUserProfileCommand : IRequest<UserProfileReturnModel>
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string Bio { get; set; }
    }
}
