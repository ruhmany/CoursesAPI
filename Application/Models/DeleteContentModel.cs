using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Models
{
    public class DeleteContentModel
    {
        public string Title { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsFound { get; set; }
    }
}
