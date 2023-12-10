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
    public class CourseCategoryConfigurations : IEntityTypeConfiguration<CourseCategory>
    {
        public void Configure(EntityTypeBuilder<CourseCategory> builder)
        {
            builder.HasKey(cc => cc.ID);

            builder.Property(cc => cc.ID).ValueGeneratedOnAdd();
            builder.Property(cc => cc.CategoryName).HasMaxLength(80);
        }
    }
}
