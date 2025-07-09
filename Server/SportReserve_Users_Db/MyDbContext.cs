using Microsoft.EntityFrameworkCore;
using SportReserveDatabase.Entities;

namespace SportReserveDatabase
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}
