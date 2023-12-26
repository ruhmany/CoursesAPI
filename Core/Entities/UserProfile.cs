using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class UserProfile : BaseEntity
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
        public bool IsBanned { get; set; }

        // Navigation property
        public virtual User User { get; set; }
    }
}
