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
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User? Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User? Get(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
