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
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }
        public int StudentsNumber { get; set; }
        public float Rating { get; set; }
        public bool IsFound { get; set; }
        public bool IsUserAuthorized { get; set; }
    }
}
