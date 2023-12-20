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
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.ID);

            builder.Property(n => n.ID).ValueGeneratedOnAdd();
            builder.Property(n => n.Message);
            builder.Property(n => n.Timestamp);
            builder.Property(n => n.IsRead);

            builder.HasOne(n => n.User).WithMany(u => u.Notifications).HasForeignKey(n => n.UserID);
        }
    }
}
