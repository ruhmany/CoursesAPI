using Application.Models;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class GetUserTokenCommand : IRequest<AuthModel>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
