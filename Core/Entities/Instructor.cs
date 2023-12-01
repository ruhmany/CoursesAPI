using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Instructor : User
    {
        public string Bio { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
