using MediatR;
using MediNet.Commands.Notifications;
using MediNet.Exceptions;
using MediNet.Models;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Notifications
{
    public class ReadNotificationHandler : IRequestHandler<ReadNotificationCommand, UserNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReadNotificationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserNotification> Handle(ReadNotificationCommand command, CancellationToken cancellationToken)
        {
            var userNoti = await _unitOfWork.UserNotificationRepository.GetAsync(command.NotificationId, command.UserId)
                ?? throw new NotFoundException("Notification Not Found.");
            userNoti.IsRead = true;
            await _unitOfWork.Save(cancellationToken);

            return userNoti;
        }
    }
}