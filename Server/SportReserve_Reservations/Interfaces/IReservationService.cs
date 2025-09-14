using SportReserve_Shared.Models.Reservation;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationService
    {
        Task AddAnimalShelterRace(AnimalShelterRace reservation, string userIdFromToken);
        Task AddLondonHalfMarathonRace(LondonHalfMarathonRace reservation, string userIdFromToken);
        Task AddValentineRace(ValentineRace reservation, string userIdFromToken);
        Task<List<ReservationBase>> Get(int userId);
    }
}
