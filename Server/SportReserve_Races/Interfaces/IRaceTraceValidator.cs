using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces
{
    public interface IRaceTraceValidator
    {
        void ValidateRaceTrace(AddRaceTraceDto? dto);
        void ThrowIfParentIdNotExist(Race? dto);
    }
}
