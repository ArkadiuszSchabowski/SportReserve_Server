using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces.Aggregates
{
    public interface IRaceTraceAggregateService : IAddService<AddRaceTraceDto>, IGetService<GetRaceTraceDto>, IRemoveService
    {
    }
}
