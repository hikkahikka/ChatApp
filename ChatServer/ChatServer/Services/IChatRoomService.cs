using ChatServer.Models.Entities;

namespace ChatServer.Services
{
    public interface IChatRoomService
    {
        Task CreateChatRoomAsync(string name);
        Task<ChatRoom> GetChatRoomAsync(Guid id);
        Task<bool> IsRoomExistAsync(Guid id);
        Task DeleteChatRoomAsync(Guid id);
        Task AddUserAsync(Guid roomId, Guid userId);
        Task RemoveUserAsync(Guid roomId, Guid userId);
        Task<List<ChatRoom>> GetUserRoomsAsync(Guid userId);
    }
}
