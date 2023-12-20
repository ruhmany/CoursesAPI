using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class Question : BaseEntity
    {        
        public int QuizID { get; set; }
        public string Text { get; set; }

        // Navigation property
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
