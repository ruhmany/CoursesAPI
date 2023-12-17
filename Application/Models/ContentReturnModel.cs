using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ContentReturnModel
    {
        public bool IsCourseFound { get; set; }
        public bool IsUserAuthorized { get; set; }
        public string Title { get; set; }        
        public string URL { get; set; }
    }
}
