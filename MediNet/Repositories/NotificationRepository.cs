using MediNet.Context;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediNet.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<NotificationDTO>> GetNotificationListByUserIdAsync(int userId)
        {
            var notifications = await _dbContext.Notifications.Include(x => x.UserNotifications).Where(n => n.UserNotifications.Any(y => y.UserId == userId))
                .Select(c => new NotificationDTO
                {
                    Id = c.Id,
                    Content = c.Content,
                    Type = c.Type,
                    EntityId = c.EntityId,
                    CreatedDate = c.CreatedDate,
                    IsRead = _dbContext.UserNotifications.FirstOrDefault(un => un.UserId == userId && un.NotificationId == c.Id).IsRead,
        }).OrderByDescending(c => c.Id).ToListAsync();
         
            return notifications;
        }

        public async Task<Notification> GetNotificationWithReceivers(int id)
        {
            return await _dbContext.Notifications.Include(n => n.UserNotifications).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<Notification>> GetUnseenByUser(int userId)
        {
            return await _dbContext.Notifications.Include(n => n.UserNotifications)
                .Where(n => n.UserNotifications.Any(un => un.UserId == userId && un.IsSeen == false))
                .OrderByDescending(n => n.CreatedDate).ToListAsync();
        }





    }
}
