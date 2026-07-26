using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChatServer.Models.Entity;
namespace ChatServer.Data.Configurations;

public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
{
    public void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder.HasKey(c => c.ChatRoomId);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}

