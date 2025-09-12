using SportReserve_Shared.Models.Reservation;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationService
    {
        Task AddReservation(AnimalShelterRace race);
    }
}
