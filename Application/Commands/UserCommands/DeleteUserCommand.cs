﻿using Application.Models;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<UserReturnModel>
    {
        public int Id { get; set; }
    }
}