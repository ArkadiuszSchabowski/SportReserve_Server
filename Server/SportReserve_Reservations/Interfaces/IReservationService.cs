using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationService<T> where T : BaseRace
    {
        Task<IActionResult?> Add(T reservation, string userIdFromToken);
    }
}
