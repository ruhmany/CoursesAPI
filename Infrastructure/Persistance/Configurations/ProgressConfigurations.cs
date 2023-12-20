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
    public class ProgressConfigurations : IEntityTypeConfiguration<Progress>
    {
        public void Configure(EntityTypeBuilder<Progress> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.CompletedPercentage);
            builder.Property(p => p.LastAccessedDate);

            builder.HasOne(p => p.User).WithMany(u => u.Progresses).HasForeignKey(p => p.UserID);
            builder.HasOne(p => p.Course).WithMany(c => c.Progresses).HasForeignKey(p => p.CourseID);
        }
    }

}
