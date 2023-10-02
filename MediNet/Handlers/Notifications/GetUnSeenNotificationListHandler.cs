using MediatR;
using MediNet.Commands.Notifications;
using MediNet.Models;
using MediNet.Queries.Notifications;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Notifications
{
    public class GetUnSeenNotificationListHandler : IRequestHandler<GetUnSeenNotificationListQuery, List<UserNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUnSeenNotificationListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<UserNotification>> Handle(GetUnSeenNotificationListQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserNotificationRepository.GetUnseen(query.UserId);

        }
    }
}
