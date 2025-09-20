using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Models;
using SportReserve_Shared.Models.Pagination;
using SportReserve_Shared.Models.Reservation.Add;
using System.Security.Claims;

namespace SportReserve_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("animal-shelter-race")]
        public async Task<IActionResult> AddAnimalShelterRace(AddAnimalShelterRace reservation)
        {
            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _service.AddAnimalShelterRace(reservation, userIdFromToken!);

            return Ok();
        }

        [Authorize]
        [HttpPost("valentine-race")]
        public async Task<IActionResult> AddValentineRace(AddValentineRace reservation)
        {
            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _service.AddValentineRace(reservation, userIdFromToken!);

            return Ok();
        }

        [Authorize]
        [HttpPost("london-half-marathon-race")]
        public async Task<IActionResult> AddLondonHalfMarathonRace(AddLondonHalfMarathonRace reservation)
        {
            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _service.AddLondonHalfMarathonRace(reservation, userIdFromToken!);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationDto dto)
        {
            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservations = await _service.Get(userIdFromToken!, dto);

            return Ok(reservations);
        }
    }
}
