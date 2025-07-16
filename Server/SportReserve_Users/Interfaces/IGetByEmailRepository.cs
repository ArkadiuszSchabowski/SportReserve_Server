using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.Interfaces
{
    public interface IGetByEmailRepository
    {
        Task<User?> Get(string email);
    }
}
