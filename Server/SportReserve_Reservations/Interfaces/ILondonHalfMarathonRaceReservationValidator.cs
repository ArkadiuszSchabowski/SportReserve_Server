using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Interfaces
{
    public interface ILondonHalfMarathonRaceReservationValidator
    {
        void ValidateLondonHalfMarathonRaceReservation(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string userId, string userIdFromToken);
    }
}
