using ChatServer.Models.Entities;

namespace ChatServer.Interfaces
{
    public interface IMessageRepository:IRepository<Message>
    {
        Task<List<Message>> GetByRoomIdAsync(Guid roomId);
    }
}
