using Microsoft.EntityFrameworkCore;
using SportReserve_Races_Db.Entities;

namespace SportReserve_Races_Db
{
    public class RaceDbContext : DbContext
    {
        public DbSet<Race> Races { get; set; }
        public RaceDbContext(DbContextOptions<RaceDbContext> options) : base(options)
        {

        }
    }
}
