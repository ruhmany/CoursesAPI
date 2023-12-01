using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByID(int id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
