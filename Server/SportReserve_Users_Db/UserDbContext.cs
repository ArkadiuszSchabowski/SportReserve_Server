using Microsoft.EntityFrameworkCore;
using SportReserveDatabase.Entities;

namespace SportReserve_Users_Db
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }
    }
}
