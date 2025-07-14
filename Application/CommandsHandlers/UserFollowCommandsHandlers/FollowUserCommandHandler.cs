using MediatR;
using RahmanyCourses.Application.Commands.UserFollowCommands;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.CommandsHandlers.UserFollowCommandsHandlers
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, bool>
    {
        private readonly IUserFollowRepository _userFollowRepository;

        public FollowUserCommandHandler(IUserFollowRepository userFollowRepository)
        {
            _userFollowRepository = userFollowRepository;
        }

        public async Task<bool> Handle(FollowUserCommand request, CancellationToken cancellationToken)
            => await _userFollowRepository.FollowUserAsync(request.UserId, request.FollowedUserId);
    }
}
