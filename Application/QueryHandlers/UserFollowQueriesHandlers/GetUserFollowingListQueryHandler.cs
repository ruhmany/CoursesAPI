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
    public class GetUserFollowingListQueryHandler : IRequestHandler<GetUserFollowingListQuery, List<User>>
    {
        private readonly IUserFollowRepository _userFollowRepository;

        public GetUserFollowingListQueryHandler(IUserFollowRepository userFollowRepository)
        {
            _userFollowRepository = userFollowRepository;
        }

        public async Task<List<User>> Handle(GetUserFollowingListQuery request, CancellationToken cancellationToken)
            => await _userFollowRepository.GetFollowing(request.UserId);
    }
}
