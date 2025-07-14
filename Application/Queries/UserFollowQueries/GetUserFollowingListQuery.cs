using MediatR;
using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Queries.UserFollowQueries
{
    public class GetUserFollowingListQuery : IRequest<List<User>>
    {
        public int UserId { get; set; }
    }
}
