using RahmanyCourses.Core.Enums;
using RahmanyCourses.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Application.Services
{
    public class NotificationService : INotificationService
    {
        public Task NotifyAsync(NotificationSubscribationType type, string recipientUserId, string message, Guid? relatedEntityId = null)
        {
            throw new NotImplementedException();
        }
    }
}
