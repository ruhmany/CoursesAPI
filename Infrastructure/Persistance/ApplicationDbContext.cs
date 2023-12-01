using Core.Entities;
using Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Instructor>(new InstuctorConfigurations());
            modelBuilder.ApplyConfiguration<Student>(new StudentConfigurations());
            modelBuilder.ApplyConfiguration<Course>(new CoursesConfigurations());
            modelBuilder.ApplyConfiguration<Enrollment>(new EnrollmentConfigurations());
            base.OnModelCreating(modelBuilder);
        }

    }
}
