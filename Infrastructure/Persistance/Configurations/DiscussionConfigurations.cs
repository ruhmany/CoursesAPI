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
    public class DiscussionConfigurations : IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.HasKey(d => d.ID);

            builder.Property(d => d.ID).ValueGeneratedOnAdd();
            builder.Property(d => d.PostDate);
            builder.Property(d => d.Message);

            builder.HasOne(d => d.User).WithMany(u => u.Discussions).HasForeignKey(d => d.UserID);
            builder.HasOne(d => d.Course).WithMany(c => c.Discussions).HasForeignKey(d => d.CourseID);
        }
    }
}
