using Microsoft.EntityFrameworkCore;
using SportReserveDatabase;
using SportReserveDatabase.Entities;
using SportReserveServer.Interfaces.Aggregates;

namespace SportReserveServer.Repositories
{
    public class UserRepository : IUserAggregateRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> Get(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Remove(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
