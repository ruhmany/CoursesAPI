using RahmanyCourses.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Configurations
{
    public class QuizConfigurations : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.ID);

            builder.Property(q => q.ID).ValueGeneratedOnAdd();
            builder.Property(q => q.Title).HasMaxLength(255);
            builder.Property(q => q.Description);

            builder.HasOne(q => q.Course).WithMany(c => c.Quizzes).HasForeignKey(q => q.CourseID);
            builder.HasMany(q => q.Questions).WithOne(qu => qu.Quiz).HasForeignKey(qu => qu.QuizID);
        }
    }
}
