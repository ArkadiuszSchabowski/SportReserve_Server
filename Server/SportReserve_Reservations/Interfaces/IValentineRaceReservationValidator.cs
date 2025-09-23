using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Interfaces
{
    public interface IValentineRaceReservationValidator
    {
        void ValidateValentineRaceReservation(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string userId, string userIdFromToken);
    }
}
