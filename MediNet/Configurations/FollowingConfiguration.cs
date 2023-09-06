using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MediNet.Models;

namespace MediNet.Configurations
{
    public class FollowingConfiguration : IEntityTypeConfiguration<Following>
    {
        public void Configure(EntityTypeBuilder<Following> builder)
        {
            builder.ToTable("Followings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.Followers).WithMany(x => x.Followings).HasForeignKey(x => x.FollowerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Followings).WithMany(x => x.Followers).HasForeignKey(x => x.FollowingId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
