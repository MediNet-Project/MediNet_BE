using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Notifications
{
    public class GetUnSeenNotificationListQuery : IRequest<List<UserNotification>>
    {
        public int UserId { get; set; }

        public GetUnSeenNotificationListQuery(int userId)
        {
            UserId = userId;
        }
    }
}
