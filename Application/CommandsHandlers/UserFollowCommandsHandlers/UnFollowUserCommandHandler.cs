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
    public class UnFollowUserCommandHandler : IRequestHandler<UnFollowUserCommand, bool>
    {
        private readonly IUserFollowRepository _userFollowRepository;

        public UnFollowUserCommandHandler(IUserFollowRepository userFollowRepository)
        {
            _userFollowRepository = userFollowRepository;
        }

        public async Task<bool> Handle(UnFollowUserCommand request, CancellationToken cancellationToken) 
            => await _userFollowRepository.UnfollowUserAsync(request.UserId, request.FollowedUserId);
        
    }
}
