using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class UsedCoupons
    {
        public int UserID { get; set; }
        public int CouponID { get; set; }
        public virtual User User { get; set; }
        public virtual Coupon Coupon { get; set; }
    }
}
