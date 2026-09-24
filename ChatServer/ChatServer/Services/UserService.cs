using ChatServer.Interfaces;
using ChatServer.Models.Entities;

namespace ChatServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(string userName)
        {
            const int MinLength = 2;
            const int MaxLength = 15;

            if (string.IsNullOrEmpty(userName) 
                || userName.Contains(' ')
                || userName.Contains('/')
                || userName.Contains('\\')
                || userName.Length < MinLength
                || userName.Length > MaxLength) throw new ArgumentException("Invalid user name format", nameof(userName));
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = userName
            };
            await  _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            if(userId == Guid.Empty) throw new ArgumentException("User id cannot be empty. ", nameof(userId));
            User user = await GetUserByIdAsync(userId);
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync(); 
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User id cannot be empty. ", nameof(userId));
            User? user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException($"User with id {userId} was not found");
            return user;
        }
    }
}
