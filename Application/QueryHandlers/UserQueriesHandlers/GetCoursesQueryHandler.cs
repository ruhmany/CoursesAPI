using Application.Queries.UserQueries;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandlers.UserQueriesHandlers
{
    internal class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<Object>>
    {
        private readonly IUserRepository _userRepository;

        public GetCoursesQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<object>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _userRepository.GetEnrolledInCourses(request.UserId);
            return courses;
        }
    }
}
