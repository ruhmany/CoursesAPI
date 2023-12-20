using RahmanyCourses.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RahmanyCourses.Core.Entities;

namespace RahmanyCourses.Infrastructure.Persistance.Configurations
{
    public class AnswerConfigurations : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.Text);
            builder.Property(a => a.IsCorrect);

            builder.HasOne(a => a.Question).WithMany(q => q.Answers).HasForeignKey(a => a.QuestionID);
        }
    }
}
