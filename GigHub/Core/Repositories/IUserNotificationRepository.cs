using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<Notification> GetNotifications(string userId);
        IEnumerable<UserNotification> GetUserNotificationsUnRead(string userId);
    }
}