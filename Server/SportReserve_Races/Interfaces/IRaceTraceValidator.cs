using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces
{
    public interface IRaceTraceValidator
    {
        void ValidateRaceTrace(AddRaceTraceDto? dto);
    }
}
