using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Enums
{
    public enum NotificationSubscribationType
    {
        NewStudentSubscription,     // Instructor notified
        FollowedInstructorUploaded, // Subscriber notified
        CourseContentUpdated,       // Course subscribers notified
        NewCourseComment            // Instructor notified
    }
}
