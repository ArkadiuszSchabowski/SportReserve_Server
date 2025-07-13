using SportReserve_Shared.Models.Workout;

namespace SportReserve_Races.Interfaces
{
    public interface IRaceValidator
    {
        void ValidateRace(AddRaceDto dto);
    }
}
