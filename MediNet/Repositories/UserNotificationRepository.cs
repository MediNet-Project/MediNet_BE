using MediNet.Context;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediNet.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserNotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddNotificationsAsync(List<UserNotification> userNotifications)
        {
            await _dbContext.AddRangeAsync(userNotifications);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<UserNotification> GetAsync(int notiId, int userId)
        {
            return await _dbContext.UserNotifications.FirstOrDefaultAsync(un => un.NotificationId == notiId && un.UserId == userId);
        }

        public async Task<List<UserNotification>> GetUnseen(int userId)
        {
            return await _dbContext.UserNotifications.Where(un => un.UserId == userId && un.IsSeen == false).ToListAsync();
        }
    }
}
