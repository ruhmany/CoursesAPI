using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);

            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Username).HasMaxLength(80);           
            builder.Property(u => u.Email).HasMaxLength(80);
            builder.Property(u => u.UserType);
            builder.Property(u => u.RegistrationDate);

            builder.HasOne(u => u.UserProfile).WithOne(up => up.User).HasForeignKey<UserProfile>(up => up.UserID);
            builder.HasMany(u => u.Enrollments).WithOne(e => e.User).HasForeignKey(e => e.UserID);
            builder.HasMany(u => u.Discussions).WithOne(d => d.User).HasForeignKey(d => d.UserID);
            builder.HasMany(u => u.Ratings).WithOne(r => r.User).HasForeignKey(r => r.UserID);
        }
    }
}
