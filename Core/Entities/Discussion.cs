using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Discussion : BaseEntity
    {        
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public DateTime PostDate { get; set; }
        public string Message { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
