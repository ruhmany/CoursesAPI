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
    public class UpdateUserEmailCommand : IRequest<UserReturnModel>
    {
        public string OldEmail { get; set; }
        public string Email { get; set; }
    }
}
