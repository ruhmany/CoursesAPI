namespace RahmanyCourses.Core.Entities
{
    public class Course : BaseEntity
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailUri { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }


        // Navigation properties
        public virtual User Instructor { get; set; }
        public virtual CourseCategory Category { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }

    }
}
