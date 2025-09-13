using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Models.Reservation;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationService
    {
        Task AddAnimalShelterRace(AnimalShelterRace reservation, string userIdFromToken);
        Task AddLondonHalfMarathonRace(LondonHalfMarathonRace reservation, string userIdFromToken);
        Task AddValentineRace(ValentineRace reservation, string userIdFromToken);
    }
}
