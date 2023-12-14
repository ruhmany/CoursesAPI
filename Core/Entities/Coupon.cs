

namespace Core.Entities
{
    public class Coupon : BaseEntity
    {
        public float DiscountPercentage { get; set; }
        public int CourseID { get; set; }
        public int Capacity { get; set; }
        public bool IsValid => Capacity > UsedCoupons.Count;
        public virtual Course Course { get; set; }
        public virtual ICollection<UsedCoupons> UsedCoupons { get; set; }
    }
}
