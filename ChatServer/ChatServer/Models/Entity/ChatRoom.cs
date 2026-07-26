namespace ChatServer.Models.Entity
{
    public class ChatRoom
    {
        public Guid ChatRoomId { get; set; }
        public string Name { get; set; } = default!;
        public List<User> Users { get; set; } = new List<User>();
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
