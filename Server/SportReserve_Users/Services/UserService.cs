using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SportReserve_Shared.Models.User;
using SportReserve_Users.Interfaces;
using SportReserve_Users.Interfaces.Aggregates;
using SportReserve_Users_Db.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportReserve_Users.Services
{
    public class UserService : IUserAggregateService
    {
        private readonly IUserAggregateRepository _repository;
        private readonly IUserAggregateValidator _validator;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IProducerUser _producer;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(IUserAggregateRepository repository, IUserAggregateValidator validator, IPasswordHasher<User> passwordHasher, IProducerUser producer, IMapper mapper, AuthenticationSettings authenticationSettings)
        {
            _repository = repository;
            _validator = validator;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _producer = producer;
            _authenticationSettings = authenticationSettings;
        }
        public async Task Add(RegisterDto dto)
        {
            _validator.ValidateUser(dto);

            User? user = await _repository.Get(dto.Email);

            _validator.ThrowIfEntityExist(user);

            User newUser = _mapper.Map<User>(dto);

            var passwordHash = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = passwordHash;
            newUser.RoleId = 1;

            await _repository.Add(newUser);

            var userRegisteredEvent = _mapper.Map<UserRegisteredEventDto>(newUser);

            _producer.RegisterEvent(userRegisteredEvent);
        }

        public async Task<TokenDto> GenerateJwt(LoginDto dto)
        {
            var user = await _repository.Get(dto.Email);

            _validator.ThrowIfUserNotFound(user);

            var result = _passwordHasher.VerifyHashedPassword(user!, user!.PasswordHash, dto.Password);

            _validator.ThrowIfInvalidLogin(result);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role!.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresDays = DateTime.Now.AddDays(_authenticationSettings.ExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
                claims,
                expires: expiresDays,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            var newToken = new TokenDto()
            {
                Token = tokenString
            };

            return newToken;
        }
        public async Task<List<GetUserDto>> Get()
        {
            var users = await _repository.Get();

            var dto = _mapper.Map<List<GetUserDto>>(users);

            return dto;
        }

        public async Task<GetUserDto> Get(int id)
        {
            _validator.ValidateId(id);

            var user = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(user);

            var dto = _mapper.Map<GetUserDto>(user);

            return dto;
        }


        public async Task<GetUserDto> GetByEmail(string email)
        {
            _validator.ValidateEmail(email);

            var user = await _repository.Get(email);

            _validator.ThrowIfEntityIsNull(user);

            var dto = _mapper.Map<GetUserDto>(user);

            return dto;
        }

        public async Task Remove(int id)
        {
            _validator.ValidateId(id);

            var user = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(user!);

            await _repository.Remove(user!);
        }

        public async Task ValidateRegisterStepOne(RegisterStepOneDto dto)
        {

            User? user = await _repository.Get(dto.Email);

            _validator.ThrowIfEntityExist(user);
        }
    }
}
