
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class UserFollow
    {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public virtual User Follower { get; set; }
        public virtual User Following { get; set; }
    }
}
