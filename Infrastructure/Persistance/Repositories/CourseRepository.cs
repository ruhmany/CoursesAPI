using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Persistance.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
