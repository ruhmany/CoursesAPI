using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Content : BaseEntity
    {        
        public int CourseID { get; set; }
        public string Title { get; set; }
        public ContentType Type { get; set; }
        public string URL { get; set; }
        public int OrderInCourse { get; set; }

        // Navigation property
        public virtual Course Course { get; set; }
    }
}
