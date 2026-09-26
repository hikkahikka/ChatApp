using ChatServer.Interfaces;
using ChatServer.Models.Entities;

namespace ChatServer.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IChatRoomRepository _chatRoomRepository;
        private readonly IUserRepository _userRepository;
        public ChatRoomService(IChatRoomRepository chatRoomRepository, IUserRepository userRepository)
        {
            _chatRoomRepository = chatRoomRepository;
            _userRepository = userRepository;
        }
        public async Task AddUserAsync(Guid roomId, Guid userId) //эээ яваще не уверен что оно не  взорвет компикъ
        {
            if (roomId == Guid.Empty) throw new ArgumentException("Chatroom id cannot be empty. ", nameof(roomId));
            if (userId == Guid.Empty) throw new ArgumentException("User id cannot be empty. ", nameof(userId));

            User? user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException($"User {userId} is not found");
            ChatRoom? chatRoom = await GetChatRoomByIdAsync(roomId);
            if (chatRoom == null) throw new KeyNotFoundException($"Chatroom {roomId} is not found");

            if (user.ChatRooms.Contains(chatRoom)) throw new ArgumentException($"{nameof(chatRoom)} already contains {userId}");
            await _chatRoomRepository.AddUserAsync(chatRoom, user);
        }

        public async Task CreateChatRoomAsync(string roomName)
        {
            const int MinLength = 2;
            const int MaxLength = 25;

            if (string.IsNullOrEmpty(roomName)
                || roomName.Contains(' ')
                || roomName.Contains('/')
                || roomName.Contains('\\')
                || roomName.Length < MinLength
                || roomName.Length > MaxLength) throw new ArgumentException("Invalid chatroom name format", nameof(roomName));
            ChatRoom chatRoom = new ChatRoom
            {
                Id = Guid.NewGuid(),
                Name = roomName
            };
            await _chatRoomRepository.AddAsync(chatRoom);
            await _chatRoomRepository.SaveChangesAsync();
        }

        public Task DeleteChatRoomAsync(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatRoom> GetChatRoomByIdAsync(Guid roomId)
        {
            if(roomId == Guid.Empty) throw new ArgumentException("Chatroom id cannot be empty. ", nameof(roomId));
            ChatRoom? chatRoom =await _chatRoomRepository.GetByIdAsync(roomId);
            if (chatRoom == null) throw new KeyNotFoundException($"Chatroom with is {chatRoom} was not found");
            return chatRoom;
        }

        public Task<List<ChatRoom>> GetUserRoomsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
        public Task<List<User>> GetRoomUsersAsync(Guid roomId)
        {
            throw new NotImplementedException() ;
        }
        public Task RemoveUserAsync(Guid roomId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
