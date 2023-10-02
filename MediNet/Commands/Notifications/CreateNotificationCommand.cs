using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Notifications
{
    public class CreateNotificationCommand : IRequest<Notification>
    {
        public int Type { get; set; }
        public string Content { get; set; }
        public int? EntityId { get; set; }
        public int[]? Receivers { get; set; }
    }
}
