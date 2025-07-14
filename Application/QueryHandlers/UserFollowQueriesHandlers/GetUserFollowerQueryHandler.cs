using MediatR;
using RahmanyCourses.Application.Queries.UserFollowQueries;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.QueryHandlers.UserFollowQueriesHandlers
{
    public class GetUserFollowerQueryHandler : IRequestHandler<GetUserFollowerQuery, List<User>>
    {
        private readonly IUserFollowRepository _userFollowRepository;

        public GetUserFollowerQueryHandler(IUserFollowRepository userFollowRepository)
        {
            _userFollowRepository = userFollowRepository;
        }

        public async Task<List<User>> Handle(GetUserFollowerQuery request, CancellationToken cancellationToken)
            => await _userFollowRepository.GetFollowers(request.UserId);
    }
}
