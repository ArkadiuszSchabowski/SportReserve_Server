using FluentAssertions;
using SportReserve_Shared.Exceptions;
using SportReserve_Users.Validators;

namespace SportReserveServerUnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class EmailValidatorUnitTests
    {
        [Theory]
        [InlineData("user@example.com")]
        [InlineData("user.name+tag@sub.domain.co.uk")]
        [InlineData("simple_email@domain.com")]
        public void ValidateEmail_WhenEmailIsValid_DoesNotThrowException(string email)
        {
            var emailValidator = new EmailValidator();

            var act = () => emailValidator.ValidateEmail(email);

            act.Should().NotThrow();
        }
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("           ")]
        public void ValidateEmail_WhenEmailNullOrWhiteSpace_ReturnsBadRequestException(string? email)
        {
            var emailValidator = new EmailValidator();

            var action = () => emailValidator.ValidateEmail(email);

            action.Should().Throw<BadRequestException>().WithMessage("Email address cannot be empty.");
        }
        [Theory]
        [InlineData("cat@.o2.pl")]
        [InlineData(" xxxXXX")]
        [InlineData("@kitty+gmail.com")]
        [InlineData("INVALID@@gmail.com")]
        [InlineData("@mail@com.pl")]
        [InlineData("tomgmail.com@")]
        public void ValidateEmail_WhenInvalidEmail_ReturnsBadRequestException(string? email)
        {
            var emailValidator = new EmailValidator();

            var action = () => emailValidator.ValidateEmail(email);

            action.Should().Throw<BadRequestException>().WithMessage("Invalid email address format.");
        }
    }
}
