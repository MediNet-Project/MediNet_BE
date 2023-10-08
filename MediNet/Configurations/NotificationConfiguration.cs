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
            builder.Property(x => x.Type).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.CreatedDate).IsRequired(true);
        }
    }
}
