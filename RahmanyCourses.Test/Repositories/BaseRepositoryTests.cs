using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RahmanyCourses.Core.Entities;
using RahmanyCourses.Infrastructure.Persistance;
using RahmanyCourses.Infrastructure.Persistance.Repositories;

namespace RahmanyCourses.Test.Repositories
{
    public class BaseRepositoryTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var context = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(context);
            databaseContext.Database.EnsureCreated();
            if(databaseContext.Courses.Count()<=0)
            {
                databaseContext.Courses.AddRange(TestDataSeeder.SeedCourseEntities(5));
                databaseContext.Courses.Add(new Course
                {
                    ID = 2,
                    Title = "C# Fundamentals",
                    Description = "Taking your from zero level to the dargon level in C# within two weeks",
                    InstructorID = 6,
                    CategoryID = 1,
                    Price = 2500,
                    CreationDate = DateTime.UtcNow
                });
                databaseContext.SaveChanges();
            }
            return databaseContext;
        }

        [Fact]
        public async void CourseRepository_GetCourse_ReturnsCourse()
        {
            // Arrange
            var id = 2;
            var dbcontext = await GetDbContext();
            var repository = new CourseRepository(dbcontext);
            
            // Act
            var result = await repository.GetById(id);
            // Assert
            result.Should().NotBeNull();    
            result.Should().BeOfType<Course>();
        }

        [Fact]
        public async void CourseRepository_GetAll_ReturnsListOfCourses()
        {
            // Arrange
            var dbcontext = await GetDbContext();
            var repository = new CourseRepository(dbcontext);

            // Act
            var result = await repository.GetAll();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<List<Course>>();
        }
    }
}
