using MediNet.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserName).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Role).IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Position).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Image).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.RefreshToken).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.RefreshTokenExpiryTime).IsRequired(false);
            builder.Property(x => x.IsDeleted).IsRequired(false);
        }
    }
}
