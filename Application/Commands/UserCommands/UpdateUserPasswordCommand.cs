﻿using RahmanyCourses.Application.Models;
using RahmanyCourses.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.UserCommands
{
    public class UpdateUserPasswordCommand : IRequest<UserReturnModel>
    {
        public int ID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
