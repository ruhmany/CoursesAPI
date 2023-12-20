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
    public class ContentConfigurations : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(co => co.ID);

            builder.Property(co => co.ID).ValueGeneratedOnAdd();
            builder.Property(co => co.Title).HasMaxLength(150);
            builder.Property(co => co.URL);

            builder.HasOne(co => co.Course).WithMany(c => c.Contents).HasForeignKey(co => co.CourseID);
        }
    }
}
