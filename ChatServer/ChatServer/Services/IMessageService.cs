using ChatServer.Models.Entities;

namespace ChatServer.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesByRoomIdAsync(Guid roomId);
        Task<List<Message>> GetMessagesByUserIdAsync(Guid userId);
        Task AddMessageAsync(Guid roomId, Guid userId, string content);
    }
}