using ChatServer.Models.Entities;

namespace ChatServer.Services
{
    public interface IChatRoomService
    {
        Task CreateChatRoomAsync(string name);
        Task<ChatRoom> GetChatRoomByIdAsync(Guid roomId);
        Task DeleteChatRoomAsync(Guid roomId);
        Task AddUserAsync(Guid roomId, Guid userId);
        Task RemoveUserAsync(Guid roomId, Guid userId);
        Task<List<ChatRoom>> GetUserRoomsAsync(Guid userId);
        Task<List<User>> GetRoomUsersAsync(Guid roomId);
    }
}
