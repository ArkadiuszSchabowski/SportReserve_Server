using SportReserve_Races.Interfaces;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Workout;

namespace SportReserve_Workouts.Interfaces.Aggregates
{
    public interface IRaceAggregateService :IAddService<AddRaceDto>, IGetService<GetRaceDto>, IRemoveService, IGetByName
    {
    }
}
