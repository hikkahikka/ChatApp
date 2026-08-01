using ChatServer.Interfaces;
using ChatServer.Models.Entities;

namespace ChatServer.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ChatDbContext context) : base(context)
        {
        }
    }
}
