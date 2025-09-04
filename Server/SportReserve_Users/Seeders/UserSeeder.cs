using SportReserve_Shared.Interfaces;
using SportReserve_Users_Db;
using SportReserve_Users_Db.Entities;
using SportReserve_Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace SportReserve_Users.Seeders
{
    public class UserSeeder : ISeeder
    {
        private readonly UserDbContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public UserSeeder(UserDbContext context, IPasswordHasher<User> hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public void SeedData()
        {
            //Temporary solution for passwords
            string userPassword = "User123";
            string moderatorPassword = "Moderator123";
            string adminPassword = "Admin123";

            if (_context.Database.CanConnect())
            {
                if (!_context.Users.Any())
                {
                    var user = new User
                    {
                        Name = "John",
                        Surname = "User",
                        Email = "user@gmail.com",
                        Gender = Gender.Male,
                        DateOfBirth = new DateOnly(1990, 01, 01),
                        RoleId = 1,
                    };

                    user.PasswordHash = _hasher.HashPassword(user, userPassword);

                    var moderator = new User
                    {
                        Name = "John",
                        Surname = "Moderator",
                        Email = "moderator@gmail.com",
                        Gender = Gender.Male,
                        DateOfBirth = new DateOnly(1990, 01, 01),
                        RoleId = 2,
                    };

                    moderator.PasswordHash = _hasher.HashPassword(moderator, moderatorPassword);

                    var admin = new User
                    {
                        Name = "John",
                        Surname = "Admin",
                        Email = "admin@gmail.com",
                        Gender = Gender.Male,
                        DateOfBirth = new DateOnly(1990, 01, 01),
                        RoleId = 3,
                    };

                    admin.PasswordHash = _hasher.HashPassword(admin, adminPassword);

                    _context.AddRange(user, moderator, admin);
                    _context.SaveChanges();
                }
            }
        }
    }
}
