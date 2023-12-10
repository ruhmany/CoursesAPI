using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations
{
    public class QuestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.ID);

            builder.Property(q => q.ID).ValueGeneratedOnAdd();
            builder.Property(q => q.Text);

            builder.HasOne(q => q.Quiz).WithMany(qu => qu.Questions).HasForeignKey(q => q.QuizID);
            builder.HasMany(q => q.Answers).WithOne(a => a.Question).HasForeignKey(a => a.QuestionID);
        }
    }
}
