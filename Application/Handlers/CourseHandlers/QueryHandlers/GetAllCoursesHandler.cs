using Application.Queries.CourseQueries;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CourseHandlers.QueryHandlers
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<Course>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetAllCoursesHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetAll();
        }
    }
}
