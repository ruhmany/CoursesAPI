using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Models
{
    public class EnrollmentReturnModel
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public bool IsUserAllowedToEnroll { get; set; }
        public bool IsCourseAvailable { get; set; }
    }
}
