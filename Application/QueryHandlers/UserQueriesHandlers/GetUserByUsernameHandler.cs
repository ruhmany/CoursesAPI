using Application.Queries.UserQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandlers.UserQueriesHandlers
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUsernameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);
            return user;
        }
    }
}
