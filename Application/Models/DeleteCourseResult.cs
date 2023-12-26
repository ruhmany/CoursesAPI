using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Models
{
    public class DeleteCourseResult
    {
        public string Title { get; set; }
        public bool IsFound { get; set; }
        public bool IsUserAuthorized { get; set; }
    }
}
