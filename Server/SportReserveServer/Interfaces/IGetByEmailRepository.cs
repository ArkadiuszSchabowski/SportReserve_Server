using SportReserveDatabase.Entities;

namespace SportReserveServer.Interfaces
{
    public interface IGetByEmailRepository
    {
        User? Get(string email);
    }
}
