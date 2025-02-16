using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<IEnumerable<Course>> GetTopRatedCourses()
        {
            var courses = await _context.Courses
                .OrderByDescending(c => c.Ratings.Average(r => r.RatingValue))
                .Take(20).ToListAsync();
            return courses;
        }

        public async Task<IEnumerable<Course>> GetEnrolledInCourses(int userId)
        {
            // Both ways have the same execution plan, giving the same result.
            var courses = await _context.Users.Where(user => user.ID == userId)
                .SelectMany(user => user.Enrollments)
                .Select(enrollment => enrollment.Course).ToListAsync();

            //var courses = from u in _context.Users
            //             join e in _context.Enrollments
            //             on u.ID equals e.UserID
            //             join c in _context.Courses
            //             on e.CourseID equals c.ID
            //             select new Course
            //             {
            //                 Title = c.Title,
            //                 Description = c.Description,
            //                 InstructorID = c.InstructorID,
            //                 CategoryID = c.CategoryID,
            //                 Price = c.Price,
            //                 CreationDate = c.CreationDate,
            //                 ID = c.ID,
            //                 Category = c.Category,
            //             };

            //var courses = _context.Users.Join(
            //    _context.Enrollments,
            //    user => user.ID,
            //    enro => enro.UserID,
            //    (user, enrollment) => new
            //    {
            //        userId = user.ID,
            //        courseId = enrollment.CourseID,
            //    }).Join(
            //    _context.Courses,
            //    enro => enro.courseId,
            //    course => course.ID,
            //    (enro, course) => new Course
            //    {
            //        Title = course.Title,
            //        Description = course.Description,
            //        InstructorID = course.InstructorID,
            //        CategoryID = course.CategoryID,
            //        Price = course.Price,
            //        CreationDate = course.CreationDate
            //    });
            return courses;
        }

        public Task<IEnumerable<Course>> GetOwnedCourses()
        {
            throw new NotImplementedException();
        }
    }
}
