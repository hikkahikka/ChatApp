using Microsoft.EntityFrameworkCore;
using ChatServer.Models.Entity;
namespace ChatServer.Data
{
    public class ChatDbContext:DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ChatRoomConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
