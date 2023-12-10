using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext Context) : base(Context)
        {
        }

        public Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
