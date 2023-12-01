namespace RahmanyCourses.Models
{
    public class CourseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EnrollmentCapacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int InstructorID { get; set; }
    }
}
