using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public async Task Add(Enrollment entity)
        {
            await _context.Enrollments.AddAsync(entity);
        }

        public void Delete(Enrollment entity)
        {
            _context.Enrollments.Remove(entity);
        }

        public async Task<List<Enrollment>> GetAll()
        {
           return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetById(int userid, int courseid)
        {
            return await _context.Enrollments.FindAsync(userid, courseid);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int Id)
        {
            return await _context.Enrollments.Where(e => e.CourseID == Id).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int Id)
        {
            return await _context.Enrollments.Where(e => e.UserID == Id).ToListAsync();
        }

        public void Update(Enrollment entity)
        {
            _context.Update(entity);
        }
    }
}
