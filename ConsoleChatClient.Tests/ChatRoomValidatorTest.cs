using ConsoleChatClient.Validators;
using System.Security.Cryptography.X509Certificates;
namespace ConsoleChatClient.Tests
{
    public class ChatRoomValidatorTest
    {
        [Theory]
        [InlineData(null, "Chat room name cannot be null or empty.")]
        [InlineData("", "Chat room name cannot be null or empty.")]
        [InlineData("/quit", "Chat room name cannot contain slashes.")]
        [InlineData("\\quit", "Chat room name cannot contain slashes.")]
        [InlineData("c", $"Chat room name must be at least 2 characters long.")]
        [InlineData("0123456789QWERTYASDFGHZXCVB", "Chat room name must be no more than 25 characters long.")]
        public void Validate_InvalidChatRoomName_ReturnFalse(string? chatRoomName, string expectedErrorMessage)
        {
            ChatRoomValidator chatRoomValidator = new ChatRoomValidator();

            bool isValid = chatRoomValidator.Validate(chatRoomName, out string actualErrorMessage);

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Theory]
        [InlineData("ValidChatRoom", "")]
        [InlineData("Valid ChatRoom", "")]
        [InlineData("/exit", "")]
        public void Validate_ValidChatRoomName_ReturnTrue(string chatRoomName, string expectedErrorMessage)
        {
            ChatRoomValidator chatRoomValidator = new ChatRoomValidator();

            bool isValid = chatRoomValidator.Validate(chatRoomName, out string actualErrorMessage);

            Assert.True(isValid);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

    }
}
