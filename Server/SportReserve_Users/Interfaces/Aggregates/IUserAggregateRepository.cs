using SportReserve_Users_Db.Entities;
using SportReserveServer.Interfaces;

namespace SportReserve_Users.Interfaces.Aggregates
{
    public interface IUserAggregateRepository : IRepository<User>, IGetByEmailRepository { }
}