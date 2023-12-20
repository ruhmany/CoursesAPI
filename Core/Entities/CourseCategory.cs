using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class CourseCategory : BaseEntity
    {
        
        public string CategoryName { get; set; }

        // Navigation property
        public virtual ICollection<Course> Courses { get; set; }
    }
}
