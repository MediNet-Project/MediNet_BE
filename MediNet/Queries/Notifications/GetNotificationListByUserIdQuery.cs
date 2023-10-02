using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Notifications
{
    public class GetNotificationListByUserIdQuery: IRequest<List<NotificationDTO>>
    {
        public int UserId { get; set; }

        public GetNotificationListByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
