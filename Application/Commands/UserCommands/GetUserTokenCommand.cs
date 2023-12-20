using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.UserCommands
{
    public class GetUserTokenCommand : IRequest<AuthModel>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
