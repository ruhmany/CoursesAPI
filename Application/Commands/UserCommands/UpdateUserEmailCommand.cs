using Core.Entities;
using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class UpdateUserEmailCommand : IRequest<User>
    {
        public string OldEmail { get; set; }
        public string Email { get; set; }
    }
}
