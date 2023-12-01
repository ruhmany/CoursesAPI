using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IInstructorRepository
    {
        Task<Instructor> GetInstructorByID(int ID);
        Task<IEnumerable<Instructor>> GetAllInstructors();
        Task AddInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void DeleteInstructor(Instructor ID);
    }
}
