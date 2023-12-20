using RahmanyCourses.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Queries.UserQueries
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string Username { get; set; }
    }
}
