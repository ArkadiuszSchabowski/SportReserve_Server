using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Reservation;
using System.Security.Claims;
using System.Text.Json;

namespace SportReserve_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService<AnimalShelterRace> _reservationService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly JsonSerializerOptions _jsonOptions;

        public ReservationController(IReservationService<AnimalShelterRace> reservationService, IHttpClientFactory httpClientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper, IOptions<JsonOptions> jsonOptions)
        {
            _reservationService = reservationService;
            _httpClientFactory = httpClientFactory;
            _httpResponseHelper = httpResponseHelper;
            _httpResponseValidator = httpResponseValidator;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [Authorize]
        [HttpPost("animal-shelter-race")]
        public async Task<IActionResult> Add([FromHeader(Name = "Authorization")] string? authorizationHeader, AnimalShelterRace reservation)
        {
            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _reservationService.Add(reservation, userIdFromToken!);

            return Ok();
        }
    }
}
