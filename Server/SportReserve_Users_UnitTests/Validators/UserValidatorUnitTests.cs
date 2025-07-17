using FluentAssertions;
using Moq;
using SportReserve_Shared.Enums;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Models.User;
using SportReserve_Users.Interfaces;
using SportReserve_Users.Validators;
using SportReserve_Users_Db.Entities;

namespace SportReserveServerUnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class UserValidatorUnitTests
    {
        private readonly Mock<IEmailValidator> _emailValidator;
        public UserValidatorUnitTests()
        {
            _emailValidator = new Mock<IEmailValidator>();
        }
        [Fact]
        public void ThrowIfDtoIsNull_WhenNull_ThrowsNotFoundException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = null;

            var action = () => userValidator.ThrowIfDtoIsNull(dto);

            action.Should().Throw<NotFoundException>().WithMessage("User data is required.");
        }

        [Fact]
        public void ThrowIfDtoIsNull_WhenNotNull_NotThrowsException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = "John", Surname = "Cena", Email = "johncena123@gmail.com", Password = "password123", RepeatPassword = "password123", Gender = Gender.Male, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ThrowIfDtoIsNull(dto);

            action.Should().NotThrow();
        }

        [Fact]
        public void ThrowIfEntityExist_WhenUserIsNotNull_ThrowsConflictException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            User? user = new User { Id = 1, Name = "Kate", Surname = "Brown", Email = "katebrown@gmail.com", Gender = Gender.Female, DateOfBirth = new DateOnly(1994, 1, 1), PasswordHash = "12345ABCDE" };

            var action = () => userValidator.ThrowIfEntityExist(user);

            action.Should().Throw<ConflictException>().WithMessage("User already exists in database.");
        }

        [Fact]
        public void ThrowIfEntityExist_WhenUserIsNull_NotThrowsException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            User? entity = null;

            var action = () => userValidator.ThrowIfEntityExist(entity);

            action.Should().NotThrow();
        }


        [Fact]
        public void ThrowIfEntityIsNull_WhenNull_ThrowsNotFoundException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            User? user = null;

            var action = () => userValidator.ThrowIfEntityIsNull(user);

            action.Should().Throw<NotFoundException>().WithMessage("User not found.");
        }

        [Fact]
        public void ThrowIfEntityIsNull_WhenNotNull_NotThrowsException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            User? user = new User { Id = 1, Name = "Kate", Surname = "Brown", Email = "katebrown@gmail.com", Gender = Gender.Female, DateOfBirth = new DateOnly(1994, 1, 1), PasswordHash = "12345ABCDE" };

            var action = () => userValidator.ThrowIfEntityIsNull(user);

            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("            ")]
        [InlineData("ab")]
        [InlineData("VeryLongNameVeryLongNameVeryLongNameLongerThan25Characters")]
        public void ValidateUser_WithInvalidName_ThrowsBadRequestException(string name)
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = name, Surname = "Cena", Email = "cena1000@gmail.com", Password = "password123", RepeatPassword = "password123", Gender = Gender.Male, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().Throw<BadRequestException>().WithMessage("User name must be between 3 and 25 characters.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("            ")]
        [InlineData("ab")]
        [InlineData("VeryLongNameVeryLongNameVeryLongNameLongerThan25Characters")]
        public void ValidateUser_WithInvalidSurname_ThrowsBadRequestException(string surname)
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = "John", Surname = surname, Email = "john@gmail.com", Password = "password123", RepeatPassword = "password123", Gender = Gender.Male, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().Throw<BadRequestException>().WithMessage("User surname must be between 3 and 25 characters.");
        }

        [Theory]
        [InlineData("cat123", "dog123")]
        [InlineData("Password123", " ")]
        [InlineData("Password", "")]
        [InlineData("PASSWORD", "password")]
        [InlineData(null, "newPassword987")]
        public void ValidateUser_WhenPasswordsNotSame_ThrowsBadRequestException(string password, string repeatPassword)
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = "John", Surname = "Brown", Email = "johnbrown123@gmail.com", Password = password, RepeatPassword = repeatPassword, Gender = Gender.Male, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().Throw<BadRequestException>().WithMessage("Passwords are not the same.");
        }

        [Theory]
        [InlineData("book", "book")]
        [InlineData("", "")]
        [InlineData("AB", "AB")]
        [InlineData("66", "66")]
        [InlineData("VERYLONGPASSWORDVERYLONGPASSWORDVERYLONGPASSWORD", "VERYLONGPASSWORDVERYLONGPASSWORDVERYLONGPASSWORD")]
        public void ValidateUser_WhenPasswordsInvalidLength_ThrowsBadRequestException(string password, string repeatPassword)
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = "John", Surname = "Brown", Email = "johnbrown1@gmail.com", Password = password, RepeatPassword = repeatPassword, Gender = Gender.Male, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().Throw<BadRequestException>().WithMessage("Password must be between 5 and 25 characters.");
        }

        [Fact]
        public void ValidateUser_WhenNotGenderSelected_ThrowsBadRequestException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = "John", Surname = "Brown", Email = "johnbrown123@gmail.com", Password = "password123", RepeatPassword = "password123", Gender = null, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().Throw<BadRequestException>().WithMessage("You must choose a gender.");
        }

        [Theory]
        [InlineData("1899-12-30")]
        [InlineData("1600-1-1")]
        [InlineData("0001-1-1")]
        public void ValidateUser_WithInvalidDateOfBirth_ThrowsBadRequestException(string dateOfBirth)
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            var date = DateOnly.Parse(dateOfBirth);

            RegisterDto? dto = new RegisterDto { Name = "John", Surname = "Brown", Email = "johnbrown123@gmail.com", Password = "password123", RepeatPassword = "password123", Gender = Gender.Male, DateOfBirth = date };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().Throw<BadRequestException>().WithMessage("Incorrect date of birth.");
        }

        [Fact]
        public void ValidateUser_WithValidData_NotThrowsException()
        {
            var userValidator = new UserValidator(_emailValidator.Object);

            RegisterDto? dto = new RegisterDto { Name = "Kate", Surname = "Brown", Email = "kate@gmail.com", Password = "PASSWORD123", RepeatPassword = "PASSWORD123", Gender = Gender.Female, DateOfBirth = new DateOnly(1985, 1, 1) };

            var action = () => userValidator.ValidateUser(dto);

            action.Should().NotThrow();
        }
    }
}
