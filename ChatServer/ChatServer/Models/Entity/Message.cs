namespace ChatServer.Models.Entity
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = default!;
        public Guid? SenderId { get; set; }
        public User? Sender { get; set; }
        public DateTime Timestamp { get; set; } =DateTime.UtcNow;
        public Guid ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; } = default!;
    }
}
