using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whisper.Core.Domain.Entities;

namespace Whisper.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.Content).IsRequired().HasMaxLength(1024);
            builder.Property(m => m.SentAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(m => m.SenderUser).WithMany(au => au.SentMessages).HasForeignKey(m => m.SenderId).IsRequired(true).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(m => m.ReceiverUser).WithMany(au => au.ReceivedMessages).HasForeignKey(m => m.ReceiverId).IsRequired(true).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
