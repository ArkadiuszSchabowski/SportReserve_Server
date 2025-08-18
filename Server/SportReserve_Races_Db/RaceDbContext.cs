using Microsoft.EntityFrameworkCore;
using SportReserve_Races_Db.Entities;

namespace SportReserve_Races_Db
{
    public class RaceDbContext : DbContext
    {
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceTrace> RaceTraces { get; set; }
        public RaceDbContext(DbContextOptions<RaceDbContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>()
                .HasMany(r => r.RaceTraces)
                .WithOne(t => t.Race)
                .HasForeignKey(t => t.ParentRaceId);

            modelBuilder.Entity<Race>()
                .Property(r => r.PosterUrl)
                .HasDefaultValue("images/default_poster.png");
        }  

    }
}
