using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IUserNotificationRepository
    {
        public Task AddNotificationsAsync(List<UserNotification> userNotifications);
        public Task<UserNotification> GetAsync(int notiId, int userId);
        public Task<List<UserNotification>> GetUnseen(int userId);
    }
}
