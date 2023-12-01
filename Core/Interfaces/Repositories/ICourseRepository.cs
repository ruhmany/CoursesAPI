using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseById(int id);
        Task<List<Course>> GetAll();
        Task AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course id);
    }
}
