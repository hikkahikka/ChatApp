using ChatServer.Models.Entities;

namespace ChatServer.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task CreateUserAsync(string userName);
        Task DeleteUserAsync(Guid userId);


    }
}