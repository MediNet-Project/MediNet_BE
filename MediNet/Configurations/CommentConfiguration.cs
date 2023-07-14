using MediNet.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(2000);
            builder.Property(x => x.IsDeleted).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CreatedAt).IsRequired(false);

            builder.HasOne(x => x.Post).WithMany(x => x.Comments).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
