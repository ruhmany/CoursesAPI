using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IEnrollmentRepository : IBaseRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int Id);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int Id);
    }
}
