using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChatServer.Models.Entity;
namespace ChatServer.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasMany(c => c.ChatRooms)
            .WithMany(r => r.Users);
    }
}
