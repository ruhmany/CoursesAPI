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
    public class UserProfileConfigurations : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.ID);

            builder.Property(up => up.ID).ValueGeneratedOnAdd();
            builder.Property(up => up.FirstName).HasMaxLength(100);
            builder.Property(up => up.LastName).HasMaxLength(100);
            builder.Property(up => up.ProfilePicture).HasMaxLength(255);
            builder.Property(up => up.Bio).HasMaxLength(4000);

            builder.HasOne(up => up.User).WithOne(u => u.UserProfile).HasForeignKey<UserProfile>(up => up.UserID);
        }
    }
}
