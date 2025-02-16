using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Models
{
    public class RatingReturnModel
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public float RatingValue { get; set; }
        public string RateMessage { get; set; }
    }
}
