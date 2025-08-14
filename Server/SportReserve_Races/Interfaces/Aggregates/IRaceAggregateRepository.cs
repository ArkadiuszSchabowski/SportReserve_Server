using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;
using SportReserveServer.Interfaces;

namespace SportReserve_Races.Interfaces.Aggregates
{
    public interface IRaceAggregateRepository : IPaginatedRepository<Race>, IGetByNameRepository, ICounterRecords
    {
    }
}
