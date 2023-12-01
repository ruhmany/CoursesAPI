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
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        async Task<Course> IRequestHandler<GetCourseByIdQuery, Course>.Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetCourseById(request.Id);
        }
    }
}
