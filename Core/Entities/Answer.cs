using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class Answer : BaseEntity
    {        
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        // Navigation property
        public virtual Question Question { get; set; }
    }
}
