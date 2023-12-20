using RahmanyCourses.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Queries.UserQueries
{
    public class GetCoursesQuery : IRequest<IEnumerable<CourseReturnModel>>
    {
        public int UserId { get; set; }
    }
}
