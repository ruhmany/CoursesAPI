using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {        
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserType UserType { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
