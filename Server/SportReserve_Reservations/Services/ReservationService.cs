using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Models.Reservation;
using System.Net.Http;

namespace SportReserve_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationAccess _reservationAccess;

        public ReservationService(IReservationAccess reservationAccess)
        {
            _reservationAccess = reservationAccess;
        }
        public async Task AddReservation(AnimalShelterRace race)
        {
            string collectionName = "reservations";

            var collection = _reservationAccess.ConnectToMongo<AnimalShelterRace>(collectionName);
            await collection.InsertOneAsync(race);
        }
    }
}
