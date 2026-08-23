using ChatServer.Hubs;
using ChatServer.Models.DTOs;
using Microsoft.AspNetCore.SignalR;
using Moq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace ChatServer.Tests
{
    public class ChatHubTest
    {

        [Fact]
        public async Task JoinChat_ValidConnection_ShouldAddUserToChat()
        {
            var userDTO = new UserDTO ("TestUser", "TestRoom" );
            var expectedConnectionID = "test-connection-id";
            ChatHub chatHub = new ChatHub();

            var mockChatClient = new Mock<IChatClient>();

            var mockClients = new Mock<IHubCallerClients<IChatClient>>();
            mockClients.Setup(client => client //10 строка в ChatHub.cs
                .Group(userDTO.ChatRoom))
                .Returns(mockChatClient.Object);


            var mockContext = new Mock<HubCallerContext>();
            mockContext.Setup(connection => connection.ConnectionId).Returns(expectedConnectionID);

            var mockGroup = new Mock<IGroupManager>();

            chatHub.Clients = mockClients.Object;
            chatHub.Context = mockContext.Object;
            chatHub.Groups = mockGroup.Object;



            await chatHub.JoinChat(userDTO);    


            mockGroup.Verify(group => group.AddToGroupAsync(expectedConnectionID, userDTO.ChatRoom, default), Times.Once);
            mockChatClient.Verify(client => client.ReceiveMessage("System", $"{userDTO.UserName} join to chat"), Times.Once);
        }
    }
}
