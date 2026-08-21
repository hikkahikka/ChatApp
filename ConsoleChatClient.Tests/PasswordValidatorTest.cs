using ConsoleChatClient.Validators;
namespace ConsoleChatClient.Tests
{
    public class PasswordValidatorTest
    {
        [Theory]
        [InlineData(null, "Password cannot be null or empty.")]
        [InlineData("", "Password cannot be null or empty.")]
        [InlineData("12345", "Password must be at least 6 characters long.")]
        [InlineData("0123456789QWERTYASDFGHZXCVB", "Password must be no more than 25 characters long.")]
        public void Validate_InvalidPassword_ReturnFalse(string? password, string expectedErrorMessage)
        {
            PasswordValidator passwordValidator = new PasswordValidator();

            bool isValid = passwordValidator.Validate(password, out string actualErrorMessage);

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
        [Fact]
        public void Validate_ValidPassword_ReturnTrue()
        {
            PasswordValidator passwordValidator = new PasswordValidator();

            bool isValid = passwordValidator.Validate("ValidPassword", out string actualErrorMessage);

            Assert.True(isValid);
            Assert.Equal("", actualErrorMessage);
        }
    }
}