using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EnrollmentCapacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
