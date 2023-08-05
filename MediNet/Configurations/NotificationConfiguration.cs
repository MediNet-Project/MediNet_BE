using MediNet.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);

            builder.HasOne(x => x.User).WithMany(x => x.Notifications).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Post).WithMany(x => x.Notifications).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Comment).WithMany(x => x.Notifications).HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Following).WithMany(x => x.Notifications).HasForeignKey(x => x.FollowingId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Reaction).WithMany(x => x.Notifications).HasForeignKey(x => x.ReactionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
