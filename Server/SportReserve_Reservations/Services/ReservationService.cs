using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Race;
using SportReserve_Shared.Models.Reservation;
using System.Text.Json;

namespace SportReserve_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationAccess _reservationAccess;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly JsonSerializerOptions _jsonOptions;

        public ReservationService(IReservationAccess reservationAccess, IHttpClientFactory httpClientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper, IOptions<JsonOptions> jsonOptions)
        {
            _reservationAccess = reservationAccess;
            _httpClientFactory = httpClientFactory;
            _httpResponseValidator = httpResponseValidator;
            _httpResponseHelper = httpResponseHelper;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }
        public async Task AddAnimalShelterRace(AnimalShelterRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";

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

            _httpResponseHelper.HandleErrorResponse(raceHttpResponse, raceResponseBody);
            _httpResponseHelper.HandleErrorResponse(raceTraceHttpResponse, raceTraceResponseBody);

            var getRaceDto = JsonConvert.DeserializeObject<GetRaceDto>(raceResponseBody);
            var getRaceTraceDto = JsonConvert.DeserializeObject<GetRaceTraceDto>(raceTraceResponseBody);

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            var collection = _reservationAccess.ConnectToMongo<AnimalShelterRace>(collectionName);
            await collection.InsertOneAsync(reservation);
        }

        public async Task AddLondonHalfMarathonRace(LondonHalfMarathonRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";

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

            _httpResponseHelper.HandleErrorResponse(raceHttpResponse, raceResponseBody);
            _httpResponseHelper.HandleErrorResponse(raceTraceHttpResponse, raceTraceResponseBody);

            var getRaceDto = JsonConvert.DeserializeObject<GetRaceDto>(raceResponseBody);
            var getRaceTraceDto = JsonConvert.DeserializeObject<GetRaceTraceDto>(raceTraceResponseBody);

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            var collection = _reservationAccess.ConnectToMongo<LondonHalfMarathonRace>(collectionName);
            await collection.InsertOneAsync(reservation);
        }

        public async Task AddValentineRace(ValentineRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";

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

            _httpResponseHelper.HandleErrorResponse(raceHttpResponse, raceResponseBody);

            _httpResponseHelper.HandleErrorResponse(raceTraceHttpResponse, raceTraceResponseBody);

            var getRaceDto = JsonConvert.DeserializeObject<GetRaceDto>(raceResponseBody);
            var getRaceTraceDto = JsonConvert.DeserializeObject<GetRaceTraceDto>(raceTraceResponseBody);

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            var collection = _reservationAccess.ConnectToMongo<ValentineRace>(collectionName);
            await collection.InsertOneAsync(reservation);
        }
    }
}
