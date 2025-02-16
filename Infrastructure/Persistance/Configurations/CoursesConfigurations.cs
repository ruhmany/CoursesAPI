using RahmanyCourses.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Configurations
{
    public class CoursesConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Title).HasMaxLength(120);
            builder.Property(c => c.Description);
            builder.Property(c => c.InstructorID);
            builder.Property(c => c.CategoryID);
            builder.Property(c => c.Price);
            builder.Property(c => c.CreationDate);
            builder.Property(c => c.ThumbnailUri);

            builder.HasOne(c => c.Category).WithMany(cc => cc.Courses).HasForeignKey(c => c.CategoryID);
            builder.HasOne(c => c.Instructor).WithMany(u => u.Courses).HasForeignKey(c => c.InstructorID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Enrollments).WithOne(e => e.Course).HasForeignKey(e => e.CourseID);
            builder.HasMany(c => c.Contents).WithOne(co => co.Course).HasForeignKey(co => co.CourseID);
        }
    }
}
