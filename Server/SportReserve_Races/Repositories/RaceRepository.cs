using Microsoft.EntityFrameworkCore;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db;
using SportReserve_Races_Db.Entities;

namespace SportReserve_Races.Repositories
{
    public class RaceRepository : IRaceAggregateRepository
    {
        private readonly RaceDbContext _context;

        public RaceRepository(RaceDbContext context)
        {
            _context = context;
        }
        public async Task Add(Race race)
        {
            _context.Races.Add(race);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Race>> Get()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race?> Get(int id)
        {
            return await _context.Races.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Race?> Get(string name)
        {
            return await _context.Races.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task Remove(Race race)
        {
            _context.Races.Remove(race);
            await _context.SaveChangesAsync();
        }
    }
}
