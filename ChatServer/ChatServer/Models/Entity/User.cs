namespace ChatServer.Models.Entity
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public List<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
