using SportReserveDatabase.Entities;

namespace SportReserveServer.Interfaces
{
    public interface IGetByEmailRepository
    {
        Task<User?> Get(string email);
    }
}
