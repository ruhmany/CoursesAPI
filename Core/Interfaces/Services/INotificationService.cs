using RahmanyCourses.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Interfaces.Services
{
    public interface INotificationService
    {
        Task NotifyAsync(NotificationSubscribationType type, string recipientUserId, string message, Guid? relatedEntityId = null);
    }
}
