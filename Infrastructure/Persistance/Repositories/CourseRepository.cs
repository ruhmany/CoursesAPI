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
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddCourse(Course course)
        {
            await _applicationDbContext.Courses.AddAsync(course);
        }

        public void DeleteCourse(Course course)
        {
            _applicationDbContext.Courses.Remove(course);
        }

        public async Task<List<Course>> GetAll()
        {
            return await _applicationDbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _applicationDbContext.Courses.FirstOrDefaultAsync(c => c.ID == id);
            return course;
        }

        public void UpdateCourse(Course course)
        {
            _applicationDbContext.Courses.Update(course);
        }
    }
}
