using MediatR;
using RahmanyCourses.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Queries.CourseQueries
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<CourseReturnModel>>
    {
    }
}
