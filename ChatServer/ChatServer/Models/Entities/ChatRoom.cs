namespace ChatServer.Models.Entities
{
    public class ChatRoom : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<User> Users { get; set; } = new List<User>();
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
