using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface INotificationRepository
    {
        public Task<List<NotificationDTO>> GetNotificationListByUserIdAsync(int userId);
        public Task<Notification> GetNotificationWithReceivers(int id);
        public Task<List<Notification>> GetUnseenByUser(int userId);
    }
}
