using Microsoft.EntityFrameworkCore;
using SportReserve_Users.Interfaces.Aggregates;
using SportReserve_Users_Db;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.Repositories
{
    public class UserRepository : IUserAggregateRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
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
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> Get(string email)
        {
            return await _context.Users.
                Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Remove(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
