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
    public class InstuctorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public InstuctorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task AddInstructor(Instructor instructor)
        {
            await _applicationDbContext.Instructors.AddAsync(instructor);
        }

        public void DeleteInstructor(Instructor instructor)
        {
            _applicationDbContext.Instructors.Remove(instructor);
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructors()
        {
            return await _applicationDbContext.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetInstructorByID(int ID)
        {
            return await _applicationDbContext.Instructors.FirstOrDefaultAsync(i => i.ID == ID);
        }

        public void UpdateInstructor(Instructor instructor)
        {
            _applicationDbContext.Instructors.Update(instructor);
        }
    }
}
