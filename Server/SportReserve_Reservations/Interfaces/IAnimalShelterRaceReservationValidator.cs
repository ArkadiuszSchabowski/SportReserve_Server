using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Interfaces
{
    public interface IAnimalShelterRaceReservationValidator
    {
        void ValidateAnimalShelterRaceReservation(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string userId, string userIdFromToken);
    }
}
