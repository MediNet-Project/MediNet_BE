using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Notifications
{
    public class ReadNotificationCommand : IRequest<UserNotification>
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }

        public ReadNotificationCommand(int notificationId, int userId)
        {
            NotificationId = notificationId;
            UserId = userId;
        }
    }
}
