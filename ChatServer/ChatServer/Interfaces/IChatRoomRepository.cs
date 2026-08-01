using ChatServer.Models.Entities;

namespace ChatServer.Interfaces
{
    public interface IChatRoomRepository :IRepository<ChatRoom>
    {
        Task <List<ChatRoom>> GetUserRoomsAsync (Guid userId);
    }
}
