using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Enrollment
    {
        public int ID { get; set; }
        public DateTime EnrollAt { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
