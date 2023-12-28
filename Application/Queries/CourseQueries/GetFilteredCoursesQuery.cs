using MediatR;
using RahmanyCourses.Application.FilterService;
using RahmanyCourses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Queries.CourseQueries
{
    public class GetFilteredCoursesQuery: IRequest<IEnumerable<Course>>
    {
        public FilterModel<Course> Filters { get; set; }
    }
}
