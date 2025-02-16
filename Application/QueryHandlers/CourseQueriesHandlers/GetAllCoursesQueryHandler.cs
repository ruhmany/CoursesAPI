using AutoMapper;
using MediatR;
using RahmanyCourses.Application.Models;
using RahmanyCourses.Application.Queries.CourseQueries;
using RahmanyCourses.Core.Interfaces.Repositories;

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
            var result = courses.Select(x => new CourseReturnModel
            {
                Title = x.Title,
                ID = x.ID,
                Price = x.Price,
                Description = x.Description,
                InstructorName = x.Instructor.Username,
                CategoryName = x.Category.CategoryName,
                StudentsNumber = x.Enrollments.Count,
                Rating = x.Ratings.Count > 0 ? x.Ratings.Average(r => r.RatingValue) : 0
            });
            // var result = _mapper.Map<IEnumerable<CourseReturnModel>>(courses);
            return result;
        }
    }
}
