using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class Rating : BaseEntity
    {        
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public float RatingValue { get; set; }
        public string RateMessage { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<RateReport> RateReports { get; set; }

    }
}
