using RahmanyCourses.Core.Entities;

namespace RahmanyCourses.Core.Interfaces.Repositories
{
    public interface IEnrollmentRepository 
    {
        Task<Enrollment> GetById(int userid, int courseid);
        Task<List<Enrollment>> GetAll();
        Task Add(Enrollment entity);
        void Update(Enrollment entity);
        void Delete(Enrollment entity);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int Id);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int Id);
    }
}
