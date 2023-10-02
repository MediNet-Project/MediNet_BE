using MediatR;
using MediNet.Commands.Notifications;
using MediNet.Models;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Notifications
{
    public class ViewNotificationHandler : IRequestHandler<ViewNotificationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ViewNotificationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ViewNotificationCommand command, CancellationToken cancellationToken)
        {
            var userNoti = await _unitOfWork.UserNotificationRepository.GetUnseen(command.UserId);
            if (userNoti != null)
            {
                foreach (var noti in userNoti)
                {
                    noti.IsSeen = true;
                }
                await _unitOfWork.Save(cancellationToken);
            }
            return true;
        }
    }
}
