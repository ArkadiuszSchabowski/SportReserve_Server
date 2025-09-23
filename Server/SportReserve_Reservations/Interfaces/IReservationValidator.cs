using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationValidator
    {
        void ValidateRace(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string raceName, string userId, string userIdFromToken);
    }
}
