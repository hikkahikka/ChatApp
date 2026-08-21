using ConsoleChatClient.Validators;
namespace ConsoleChatClient.Tests
{
    public class LoginValidatorTest
    {
        [Theory]
        [InlineData(null, "Login cannot be null or empty.")]
        [InlineData("", "Login cannot be null or empty.")]
        [InlineData("Sviridov Boris", "Login cannot contain spaces.")]
        [InlineData("/quit", "Login cannot contain slashes.")]
        [InlineData("\\quit", "Login cannot contain slashes.")]
        [InlineData("b", $"Login must be at least 2 characters long.")]
        [InlineData("0123456789ABCDEFG", "Login must be no more than 15 characters long.")]
        public void Validate_InvalidLogin_ReturnFalse(string? login, string expectedErrorMessage)
        {
            LoginValidator loginValidator = new LoginValidator();

            bool isValid = loginValidator.Validate(login, out string actualErrorMessage);

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Theory]
        [InlineData("ValidLogin", "")]
        [InlineData("Valid_Login", "")]
        public void Validate_ValidLogin_ReturnTrue(string? login, string? expectedErrorMessage)
        {
            LoginValidator loginValidator = new LoginValidator();

            bool isValid = loginValidator.Validate(login, out string actualErrorMessage);

            Assert.True(isValid);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
    }
}
