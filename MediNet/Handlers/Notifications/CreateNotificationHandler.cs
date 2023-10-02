using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Notifications;
using MediNet.Models;
using MediNet.Repositories;
using MediNet.Repositories.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediNet.Handlers.Notifications
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, Notification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateNotificationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Notification> Handle(CreateNotificationCommand command, CancellationToken cancellationToken)
        {

            var newNotification = new Notification()
            {
                Type = (Models.Enums.Type)command.Type,
                Content = command.Content,
                EntityId = (command.EntityId == 0 || command.EntityId == null) ? null : command.EntityId,
            };
            await _unitOfWork.Repository<Notification>().AddAsync(newNotification);
            await _unitOfWork.Save(cancellationToken);

            if (command.Receivers != null)
            {
                var userNotifications = new List<UserNotification>();
                foreach (var un in command.Receivers)
                {
                    var userNotification = new UserNotification
                    {
                        UserId = un,
                        NotificationId = newNotification.Id,
                    };
                    userNotifications.Add(userNotification);
                }
                await _unitOfWork.UserNotificationRepository.AddNotificationsAsync(userNotifications);
                await _unitOfWork.Save(cancellationToken);
            }
            return newNotification;
        }
    }
}
