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
    public class RatingConfigurations : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.ID);


            builder.Property(r => r.ID).ValueGeneratedOnAdd();

            builder.HasOne(r => r.User).WithMany(u => u.Ratings).HasForeignKey(r => r.UserID);
            builder.HasOne(r => r.Course).WithMany(c => c.Ratings).HasForeignKey(r => r.CourseID);
        }
    }
}
