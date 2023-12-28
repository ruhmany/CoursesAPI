using MediatR;
using RahmanyCourses.Application.FilterService;
using RahmanyCourses.Application.Queries.CourseQueries;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.QueryHandlers.CourseQueriesHandlers
{
    internal class GetFilteredCoursesQueryHandler : IRequestHandler<GetFilteredCoursesQuery, IEnumerable<Course>>
    {
        private readonly ICourseRepository _repository;
        private readonly GenericFilter<Course> _genericFilter;

        public GetFilteredCoursesQueryHandler(ICourseRepository repository, GenericFilter<Course> genericFilter)
        {
            _repository = repository;
            _genericFilter = genericFilter;
        }

        public Task<IEnumerable<Course>> Handle(GetFilteredCoursesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQueryableData();
            var filteredQuery = _genericFilter.ApplyFilter(query, request.Filters);

            var result = filteredQuery.AsEnumerable();

            return Task.FromResult(result);
        }
    }
