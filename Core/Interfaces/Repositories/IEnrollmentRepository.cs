using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> GetEnrollmentByID(int id);
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Task AddEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(Enrollment enrollment);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int Id);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int Id);
    }
}
