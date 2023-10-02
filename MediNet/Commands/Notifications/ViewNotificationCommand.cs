using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Notifications
{
    public class ViewNotificationCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public ViewNotificationCommand(int userId)
        {
            UserId = userId;
        }
    }
}
