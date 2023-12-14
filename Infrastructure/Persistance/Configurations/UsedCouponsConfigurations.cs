using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    internal class UsedCouponsConfigurations : IEntityTypeConfiguration<UsedCoupons>
    {
        public void Configure(EntityTypeBuilder<UsedCoupons> builder)
        {
            builder.HasKey(uc => new { uc.UserID, uc.CouponID });
            builder.HasOne(uc => uc.User).WithMany(u => u.UsedCoupons).HasForeignKey(uc => uc.UserID);
            builder.HasOne(uc => uc.Coupon).WithMany(c => c.UsedCoupons).HasForeignKey(c => c.CouponID);
        }
    }
}
