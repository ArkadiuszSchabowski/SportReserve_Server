#nullable disable

using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using SportReserve_Shared.Enums;
using SportReserve_Shared.Models.User;
using SportReserve_Users;
using SportReserve_Users.Interfaces;
using SportReserve_Users.Interfaces.Aggregates;
using SportReserve_Users.Services;
using SportReserve_Users_Db.Entities;

namespace SportReserveServerUnitTests.Services
{
    [Trait("Category", "Unit")]
    public class UserServiceUnitTests
    {
        private readonly Mock<IUserAggregateRepository> _mockRepository;
        private readonly Mock<IUserAggregateValidator> _mockValidator;
        private readonly Mock<IPasswordHasher<User>> _mockPasswordHasher;
        private readonly Mock<IProducerUser> _mockProducer;
        private readonly Mock<IMapper> _mockMapper;
        public UserServiceUnitTests()
        {
            _mockRepository = new Mock<IUserAggregateRepository>();
            _mockValidator = new Mock<IUserAggregateValidator>();
            _mockPasswordHasher = new Mock<IPasswordHasher<User>>();
            _mockProducer = new Mock<IProducerUser>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public async Task Add_WithValidDto_InvokeRepositoryAddMethodOnce()
        {
            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, null);

            var dto = new RegisterDto() { Name = "James", Surname = "Wiliams", Email = "wiliams@gmail.com", Gender = Gender.Male, DateOfBirth = DateOnly.Parse("01.01.1990"), Password = "James123", RepeatPassword = "James123" };

            var user = new User
            {
                Name = "James",
                Surname = "Wiliams",
                Email = "wiliams@gmail.com",
                Gender = Gender.Male,
                DateOfBirth = DateOnly.Parse("01.01.1990"),
                PasswordHash = "123XYZ"
            };

            _mockMapper.Setup(x => x.Map<User>(dto)).Returns(user);

            await userService.Add(dto);

            _mockRepository.Verify(x => x.Add(user), Times.Once);
        }
        [Fact]
        public async Task Get_WithoutUsers_ReturnsEmptyList()
        {
            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, null);

            var users = new List<User>();
            var usersDto = new List<GetUserDto>();

            _mockRepository.Setup(x => x.Get()).ReturnsAsync(users);
            _mockMapper.Setup(x => x.Map<List<GetUserDto>>(users)).Returns(usersDto);

            var expectedResult = new List<GetUserDto>();
            var result = await userService.Get();

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Get_WithUsers_ReturnsUsersDtoList()
        {
            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, null);

            var users = new List<User>()
            {
                new User()
                {
                    Id = 1, Email = "jamesbrown@gmail.com", Name = "James", Surname = "Brown", Gender = Gender.Male, PasswordHash = "123XYZ", DateOfBirth = DateOnly.Parse("01.01.1990")
                },
                new User()
                {
                    Id = 2, Email = "kate99@onet.pl", Name = "Kate", Surname = "Brown", Gender = Gender.Female,
                    PasswordHash = "ABC123", DateOfBirth = DateOnly.Parse("02.03.1994")
                }
            };

            var usersDto = new List<GetUserDto>()
            {
                new GetUserDto()
                {
                    Id = 1, Email = "jamesbrown@gmail.com", Name = "James", Surname = "Brown", Gender = Gender.Male, DateOfBirth = DateOnly.Parse("01.01.1990")
                },
                new GetUserDto()
                {
                    Id = 2, Email = "kate99@onet.pl", Name = "Kate", Surname = "Brown", Gender = Gender.Female,
                    DateOfBirth = DateOnly.Parse("02.03.1994")
                }
            };

            _mockRepository.Setup(x => x.Get()).ReturnsAsync(users);
            _mockMapper.Setup(x => x.Map<List<GetUserDto>>(users)).Returns(usersDto);

            var expectedResult = usersDto;
            var result = await userService.Get();

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GenerateJWT_WhenValidLogin_ShouldGenerateJWTToken()
        {

            var authenticationSettings = new AuthenticationSettings()
            {
                ExpireDays = 1,
                JwtKey = "TestKey TestKey TestKey TestKey TestKey",
                JwtIssuer = "Test Issuer"
            };

            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, authenticationSettings);

            var dto = new LoginDto { Email = "jamesbrown@gmail.com", Password = "James123" };

            var role = new Role
            {
                Id = 1,
                Name = "User"
            };

            var user = new User()
            {
                Id = 1,
                Email = "jamesbrown@gmail.com",
                Name = "James",
                Surname = "Brown",
                Gender = Gender.Male,
                PasswordHash = "123XYZ",
                DateOfBirth = DateOnly.Parse("01.01.1990"),
                RoleId = 1,
                Role = role
            };

            

            _mockRepository.Setup(x => x.Get(dto.Email)).ReturnsAsync(user);
            _mockPasswordHasher.Setup(x => x.VerifyHashedPassword(user, user.PasswordHash, dto.Password)).Returns(PasswordVerificationResult.Success);

            TokenDto token = await userService.GenerateJwt(dto);

            token.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(999)]
        public async Task Get_Id_WithValidId_ShouldInvokeMappingToGetUserDtoOnce(int id)
        {
            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, null);

            var user = new User();
            var userDto = new GetUserDto();

            _mockRepository.Setup(x => x.Get(id)).ReturnsAsync(user);
            _mockMapper.Setup(x => x.Map<GetUserDto>(user)).Returns(userDto);

            await userService.Get(id);

            _mockMapper.Verify(x => x.Map<GetUserDto>(user), Times.Once);
        }

        [Theory]
        [InlineData("james@gmail.com")]
        [InlineData("James123@wp.pl")]
        [InlineData("RANDOMEMAIL91@onet.pl")]
        public async Task GetByEmail_WithValidEmail_ShouldInvokeMappingToGetUserDtoOnce(string email)
        {
            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, null);

            var user = new User();
            var userDto = new GetUserDto();

            _mockRepository.Setup(x => x.Get(email)).ReturnsAsync(user);
            _mockMapper.Setup(x => x.Map<GetUserDto>(user)).Returns(userDto);

            await userService.GetByEmail(email);

            _mockMapper.Verify(x => x.Map<GetUserDto>(user), Times.Once);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(30)]
        [InlineData(767)]
        [InlineData(1000)]
        public async Task Remove_WithValidId_ShoudInvokeRemoveFromRepositoryOnce(int id)
        {
            var userService = new UserService(_mockRepository.Object, _mockValidator.Object, _mockPasswordHasher.Object, _mockProducer.Object, _mockMapper.Object, null);

            var user = new User();
            var userDto = new GetUserDto();

            _mockRepository.Setup(x => x.Get(id)).ReturnsAsync(user);
            _mockMapper.Setup(x => x.Map<GetUserDto>(user)).Returns(userDto);

            await userService.Remove(id);

            _mockRepository.Verify(x => x.Remove(user), Times.Once);
        }
    }
}
