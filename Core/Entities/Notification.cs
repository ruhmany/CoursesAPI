using RahmanyCourses.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class Notification : BaseEntity
    {        
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public NotificationType NotificationType { get; set; }

        // Navigation property
        public virtual User User { get; set; }
    }
}
