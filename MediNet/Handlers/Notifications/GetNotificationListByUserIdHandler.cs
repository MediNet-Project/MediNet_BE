using MediatR;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Queries.Notifications;
using MediNet.Queries.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Notifications
{
    public class GetNotificationListByUserIdHandler : IRequestHandler<GetNotificationListByUserIdQuery, List<NotificationDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
    public GetNotificationListByUserIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

        public async Task<List<NotificationDTO>> Handle(GetNotificationListByUserIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.NotificationRepository.GetNotificationListByUserIdAsync(query.UserId);
        }
}
}
