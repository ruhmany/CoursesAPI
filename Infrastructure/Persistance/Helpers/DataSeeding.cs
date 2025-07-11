using RahmanyCourses.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace RahmanyCourses.Infrastructure.Persistance.Helpers
{
    public static class DataSeeding
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<CourseCategory>().HasData(
                new CourseCategory { ID = 1,  CategoryName = "Programming"},
                new CourseCategory {ID = 2, CategoryName = "Database"},
                new CourseCategory {ID = 3, CategoryName = "Software Engnireeing"},
                new CourseCategory {ID = 4, CategoryName = "Project Managment"});
            builder.Entity<Course>().HasData(
                new Course { 
                    ID = 1,
                    Title = "PHP Fundamentals", 
                    Description = "Taking your from zero level to the dargon level in php within two weeks"
                , InstructorID = 5, CategoryID = 1, Price = 1250
                , CreationDate = DateTime.UtcNow},
                new Course
                {
                    ID = 2,
                    Title = "C# Fundamentals",
                    Description = "Taking your from zero level to the dargon level in C# within two weeks",
                    InstructorID = 6,
                    CategoryID = 1,
                    Price = 2500,
                    CreationDate = DateTime.UtcNow
                },
                new Course
                {
                    ID = 3,
                    Title = "SQL Fundamentals",
                    Description = "Taking your from zero level to the dargon level in php within two weeks",
                    InstructorID = 6,
                    CategoryID = 2,
                    Price = 1500,
                    CreationDate = DateTime.UtcNow
                },
                new Course
                {
                    ID= 4,
                    Title = "Full-Stack Web Development Using PHO",
                    Description = "Taking your from zero level to the dargon level in full-stack web development using php within two weeks"
                ,
                    InstructorID = 5,
                    CategoryID = 3,
                    Price = 1200
                ,
                    CreationDate = DateTime.UtcNow
                });
            builder.Entity<Enrollment>().HasData(
                new Enrollment { UserID = 1, CourseID=1 },
                new Enrollment { UserID = 1, CourseID = 4 },
                new Enrollment { UserID = 2, CourseID = 3 },
                new Enrollment { UserID = 2, CourseID = 2 },
                new Enrollment { UserID = 3, CourseID = 3 },
                new Enrollment { UserID = 3, CourseID = 4 },
                new Enrollment { UserID = 4, CourseID = 4 },
                new Enrollment { UserID = 4, CourseID = 2 }
                );

            builder.Entity<Role>().HasData(
                new Role { ID = 1, CreatedAt = DateTime.Now, IsDeleted = false, RoleName = "SuperAdmin", UpdatedAt = DateTime.Now },
                new Role { ID = 2, CreatedAt = DateTime.Now, IsDeleted = false, RoleName = "Instructor", UpdatedAt = DateTime.Now },
                new Role { ID = 3, CreatedAt = DateTime.Now, IsDeleted = false, RoleName = "Student", UpdatedAt = DateTime.Now }
                );
        }
    }
}
