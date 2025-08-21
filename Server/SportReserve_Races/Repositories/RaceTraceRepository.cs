using Microsoft.EntityFrameworkCore;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db;
using SportReserve_Races_Db.Entities;

namespace SportReserve_Races.Repositories
{
    public class RaceTraceRepository : IRaceTraceAggregateRepository
    {
        private readonly RaceDbContext _context;
        public RaceTraceRepository(RaceDbContext context)
        {
            _context = context;
        }
        public async Task Add(RaceTrace entity)
        {
            _context.RaceTraces.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<RaceTrace>> Get()
        {
            return await _context.RaceTraces.ToListAsync();
        }

        public async Task<RaceTrace?> Get(int id)
        {
            return await _context.RaceTraces.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Race?> GetParent(int id)
        {
            return await _context.Races.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remove(RaceTrace raceTrace)
        {
            _context.RaceTraces.Remove(raceTrace);
            await _context.SaveChangesAsync();
        }
    }
}
