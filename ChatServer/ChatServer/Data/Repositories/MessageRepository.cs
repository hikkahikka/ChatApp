using ChatServer.Interfaces;
using ChatServer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatServer.Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ChatDbContext context) : base(context)
        {
        }

        public async Task<List<Message>> GetByRoomIdAsync(Guid roomId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(m => m.ChatRoomId == roomId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }
    }
}
