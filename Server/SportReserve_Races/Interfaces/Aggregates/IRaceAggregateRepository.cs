using SportReserve_Races_Db.Entities;
using SportReserveServer.Interfaces;

namespace SportReserve_Races.Interfaces.Aggregates
{
    public interface IRaceAggregateRepository : IRepository<Race>, IGetByNameRepository
    {
    }
}
