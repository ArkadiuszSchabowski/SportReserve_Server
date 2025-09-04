using SportReserve_Shared.Interfaces;
using SportReserve_Users_Db;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.Seeders
{
    public class RoleSeeder : ISeeder
    {
        private readonly UserDbContext _context;

        public RoleSeeder(UserDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {

            if (_context.Database.CanConnect())
            {
                if (!_context.Roles.Any())
                {
                    var roles = new List<Role>()
                    {
                        new Role()
                        {
                            Name = "user"
                        },
                        new Role() {
                            Name = "moderator"
                        },
                        new Role()
                        {
                            Name = "admin"
                        }
                    };

                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();
                }
            }
        }
    }
}
