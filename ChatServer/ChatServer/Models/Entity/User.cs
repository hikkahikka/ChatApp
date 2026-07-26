namespace ChatServer.Models.Entity
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public Guid? ChatRoomId { get; set; }
        public ChatRoom? ChatRoom { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
