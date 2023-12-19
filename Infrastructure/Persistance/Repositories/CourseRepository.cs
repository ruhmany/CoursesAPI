using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<IEnumerable<Course>> GetTopRatedCourses()
        {
            var courses = await _context.Courses
                .OrderByDescending(c => c.Ratings.Average(r => r.RatingValue))
                .Take(20).ToListAsync();
            return courses;
        }
    }
}
