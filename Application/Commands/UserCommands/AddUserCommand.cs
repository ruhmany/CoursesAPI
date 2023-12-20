using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.UserCommands
{
    public class AddUserCommand : IRequest<AuthModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }        
    }
}
