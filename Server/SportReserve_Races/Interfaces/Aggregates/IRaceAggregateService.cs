using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces.Aggregates
{
    public interface IRaceAggregateService :IAddService<AddRaceDto>, IPaginatedGetService<GetRaceDto>, IRemoveService, IGetByName, IUpdate<UpdateRaceDto>
    {
    }
}
