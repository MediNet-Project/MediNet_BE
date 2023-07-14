using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MediNet.Models;

namespace MediNet.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FileName).IsRequired(false).HasMaxLength(200);

            builder.HasOne(x => x.Post).WithMany(x => x.Attachments).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
