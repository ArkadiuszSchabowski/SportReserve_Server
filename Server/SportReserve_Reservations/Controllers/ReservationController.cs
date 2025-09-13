using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Models.Reservation;
using System.Security.Claims;

namespace SportReserve_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService<AnimalShelterRace> _reservationService;

        public ReservationController(IReservationService<AnimalShelterRace> reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize]
        [HttpPost("animal-shelter-race")]
        public async Task<IActionResult> Add(AnimalShelterRace reservation)
        {
            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _reservationService.Add(reservation, userIdFromToken!);

            return Ok();
        }
    }
}
