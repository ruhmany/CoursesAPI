using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserQueries
{
    public class GetCoursesQuery : IRequest<IEnumerable<object>>
    {
        public int UserId { get; set; }
    }
}
