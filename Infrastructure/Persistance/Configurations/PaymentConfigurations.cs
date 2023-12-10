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
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.Amount);
            builder.Property(p => p.PaymentDate);

            builder.HasOne(p => p.User).WithMany(u => u.Payments).HasForeignKey(p => p.UserID);
            builder.HasOne(p => p.Course).WithMany(c => c.Payments).HasForeignKey(p => p.CourseID);
        }
    }
}
