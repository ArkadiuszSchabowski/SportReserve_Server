using Microsoft.EntityFrameworkCore;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Models.Pagination;

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

        public async Task<int> CountRecords()
        {
            return await _context.Races.CountAsync();
        }

        public async Task<List<Race>> Get(PaginationDto dto)
        {
            return await _context.Races
                .OrderBy(x => x.DateOfStart)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .Include(x => x.RaceTraces)
                .ToListAsync();
        }

        public async Task<Race?> Get(int id)
        {
            return await _context.Races.Include(x => x.RaceTraces).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Race?> Get(string name)
        {
            return await _context.Races.Include(x => x.RaceTraces).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task Remove(Race race)
        {
            _context.Races.Remove(race);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
