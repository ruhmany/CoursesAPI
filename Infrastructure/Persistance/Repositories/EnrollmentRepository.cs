using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEnrollment(Enrollment enrollment)
        {
             await _context.Enrollments.AddAsync(enrollment);
        }

        public void DeleteEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentByID(int id)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int Id)
        {
            return await _context.Enrollments.Where(e => e.CourseID == Id).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int Id)
        {
            return await _context.Enrollments.Where(e => e.StudentID == Id).ToListAsync();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
        }
    }
}
