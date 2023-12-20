using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class Progress : BaseEntity
    {        
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int CompletedPercentage { get; set; }
        public DateTime LastAccessedDate { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
