using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Models
{
    public class CourseReturnModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }
        public int StudentsNumber { get; set; }
        public float Rating { get; set; }
    }
}
