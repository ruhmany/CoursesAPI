using AutoMapper;
using MediatR;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.CourseQueries;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.QueryHandlers.CourseQueriesHandlers
{
    internal class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseReturnModel>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetAllCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseReturnModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAll();
            var result = _mapper.Map<IEnumerable<CourseReturnModel>>(courses);
            return result;
        }
    }
}
