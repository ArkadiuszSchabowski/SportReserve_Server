using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Race;
using SportReserve_Shared.Models.Reservation;
using System.Security.Claims;
using System.Text.Json;

namespace SportReserve_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly JsonSerializerOptions _jsonOptions;

        public ReservationController(IReservationService reservationService, IHttpClientFactory httpClientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper, IOptions<JsonOptions> jsonOptions)
        {
            _reservationService = reservationService;
            _httpClientFactory = httpClientFactory;
            _httpResponseHelper = httpResponseHelper;
            _httpResponseValidator = httpResponseValidator;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [Authorize]
        [HttpPost("animal-shelter-race")]
        public async Task<ActionResult> AddAnimalSheleterRaceReservation([FromHeader(Name = "Authorization")] string? authorizationHeader, AnimalShelterRace reservation)
        {
            var raceClient = _httpClientFactory.CreateClient("RaceService");
            var raceTraceClient = _httpClientFactory.CreateClient("RaceTraceService");

            var raceTask = raceClient.GetAsync($"{reservation.RaceId}");
            var raceTraceTask = raceTraceClient.GetAsync($"{reservation.RaceTraceId}");

            await Task.WhenAll(raceTask, raceTraceTask);

            var raceHttpResponse = await raceTask;
            var raceTraceHttpResponse = await raceTraceTask;

            _httpResponseValidator.ThrowIfResponseIsNull(raceHttpResponse);
            _httpResponseValidator.ThrowIfResponseIsNull(raceTraceHttpResponse);

            var raceResponseBody = await raceHttpResponse.Content.ReadAsStringAsync();
            var raceTraceResponseBody = await raceTraceHttpResponse.Content.ReadAsStringAsync();

            var actionResultRace = _httpResponseHelper.HandleErrorResponse(raceHttpResponse, raceResponseBody);

            if (actionResultRace != null)
            {
                return actionResultRace;
            }

            var actionResultRaceTrace = _httpResponseHelper.HandleErrorResponse(raceTraceHttpResponse, raceTraceResponseBody);

            if (actionResultRaceTrace != null)
            {
                return actionResultRaceTrace;
            }

            var getRaceDto = JsonConvert.DeserializeObject<GetRaceDto>(raceResponseBody);
            var getRaceTraceDto = JsonConvert.DeserializeObject<GetRaceTraceDto>(raceTraceResponseBody);

            if(getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            var userIdFromToken = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            await _reservationService.AddReservation(reservation);

            return Ok();
        }
    }
}
