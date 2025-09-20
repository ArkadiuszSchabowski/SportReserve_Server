using SportReserve_Shared.Models.Pagination;
using SportReserve_Shared.Models.Reservation.Add;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationService
    {
        Task AddAnimalShelterRace(AddAnimalShelterRace reservation, string userIdFromToken);
        Task AddLondonHalfMarathonRace(AddLondonHalfMarathonRace reservation, string userIdFromToken);
        Task AddValentineRace(AddValentineRace reservation, string userIdFromToken);
        Task<PaginationResult<ReservationBase>> Get(string userId, PaginationDto dto);
    }
}
