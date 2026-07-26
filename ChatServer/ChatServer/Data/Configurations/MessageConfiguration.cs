using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChatServer.Models.Entity;
namespace ChatServer.Data.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.MessageId);
        builder.HasOne(s => s.Sender)
            .WithMany(m => m.Messages)
            .HasForeignKey(s => s.SenderId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(c => c.ChatRoom)
            .WithMany(m => m.Messages)
            .HasForeignKey(c => c.ChatRoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

