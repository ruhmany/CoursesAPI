using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.AsQueryable().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetEnrolledInCourses(int userId)
        {
            var courses = await _context.Users.Where(user => user.ID == userId)
                .SelectMany(user => user.Enrollments)
                .Select(enrollment => enrollment.Course).ToListAsync();
            return courses;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.AsQueryable().Where(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}
