using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Quiz : BaseEntity
    {        
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation property
        public virtual Course Course { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
