using SportReserveDatabase.Entities;

namespace SportReserveServer.Interfaces.Aggregates
{
    public interface IUserAggregateRepository : IRepository<User>, IGetByEmailRepository { }
}