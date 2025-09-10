using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces
{
    public interface IRaceValidator
    {
        void ValidateRace(AddRaceDto? dto);
        void ValidateUpdatedRace(UpdateRaceDto? dto);
    }
}
