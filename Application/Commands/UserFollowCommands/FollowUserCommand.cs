using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Commands.UserFollowCommands
{
    public class FollowUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int FollowedUserId { get; set; }
    }
}
