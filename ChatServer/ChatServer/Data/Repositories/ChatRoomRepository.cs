using ChatServer.Interfaces;
using ChatServer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatServer.Data.Repositories
{
    public class ChatRoomRepository : Repository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(ChatDbContext context) : base(context)
        {
        }

        public async Task<List<ChatRoom>> GetUserRoomsAsync(Guid userId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(room => room.Users.Any(user => user.Id == userId))
                .ToListAsync();
        }
    }
}
