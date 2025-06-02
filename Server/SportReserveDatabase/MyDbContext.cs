using Microsoft.EntityFrameworkCore;

namespace SportReserveDatabase
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}
