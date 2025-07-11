using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class RolePermission
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
