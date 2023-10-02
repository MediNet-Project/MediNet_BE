using MediNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediNet.Configurations
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.ToTable("UserNotifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsSeen).IsRequired(true);
            builder.Property(x => x.IsRead).IsRequired(true);
            builder.HasOne(x => x.User).WithMany(x => x.UserNotifications).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Notification).WithMany(x => x.UserNotifications).HasForeignKey(x => x.NotificationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
