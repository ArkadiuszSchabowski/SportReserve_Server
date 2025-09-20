using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Race;
using SportReserve_Shared.Models.Reservation;
using SportReserve_Shared.Models.Reservation.Add;
using SportReserve_Shared.Models.Reservation.Base;
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
        public async Task AddAnimalShelterRace(AddAnimalShelterRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";
            string raceName = "Run for the Animal Shelter";

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

            if(getRaceDto!.Name != raceName)
            {
                throw new BadRequestException("The provided race details do not match the expected race.");
            }

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            var collection = _reservationAccess.ConnectToMongo<AnimalShelterRace>(collectionName);

            var animalShelterRace = new AnimalShelterRace()
            {
                Id = reservation.Id,
                DogSize = reservation.DogSize,
                DonationAmount = reservation.DonationAmount,
                EmergencyContact = reservation.EmergencyContact,
                RaceId = getRaceDto.Id,
                RaceName = getRaceDto.Name,
                RaceTraceId = getRaceTraceDto.Id,
                DateOfStart = getRaceDto.DateOfStart,
                HourOfStart = getRaceTraceDto.HourOfStart,
                DistanceKm = getRaceTraceDto.DistanceKm,
                Location = getRaceTraceDto.Location,
                UserId = int.Parse(userIdFromToken),
            };

            await collection.InsertOneAsync(animalShelterRace);
        }

        public async Task AddLondonHalfMarathonRace(AddLondonHalfMarathonRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";
            string raceName = "London Half-Marathon Race";

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

            if (getRaceDto!.Name != raceName)
            {
                throw new BadRequestException("The provided race details do not match the expected race.");
            }

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            var collection = _reservationAccess.ConnectToMongo<LondonHalfMarathonRace>(collectionName);

            var londonHalfMarathonRace = new LondonHalfMarathonRace()
            {
                Id = reservation.Id,
                MedalGratification = reservation.MedalGratification,
                TeamName = reservation.TeamName,
                TShirtSize = reservation.TShirtSize,
                RaceId = getRaceDto.Id,
                RaceName = getRaceDto.Name,
                RaceTraceId = getRaceTraceDto.Id,
                DateOfStart = getRaceDto.DateOfStart,
                HourOfStart = getRaceTraceDto.HourOfStart,
                DistanceKm = getRaceTraceDto.DistanceKm,
                Location = getRaceTraceDto.Location,
                UserId = int.Parse(userIdFromToken),
            };

            await collection.InsertOneAsync(londonHalfMarathonRace);
        }

        public async Task AddValentineRace(AddValentineRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";
            string raceName = "Valentine Race with Heart";

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

            if (getRaceDto!.Name != raceName)
            {
                throw new BadRequestException("The provided race details do not match the expected race.");
            }

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (reservation.UserId.ToString() != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }

            var collection = _reservationAccess.ConnectToMongo<ValentineRace>(collectionName);

            var valentineRace = new ValentineRace()
            {
                Id = reservation.Id,
                RaceId = getRaceDto.Id,
                RaceName = getRaceDto.Name,
                RaceTraceId = getRaceTraceDto.Id,
                DateOfStart = getRaceDto.DateOfStart,
                HourOfStart = getRaceTraceDto.HourOfStart,
                DistanceKm = getRaceTraceDto.DistanceKm,
                Location = getRaceTraceDto.Location,
                UserId = int.Parse(userIdFromToken),
                RunType = reservation.RunType,
                ValentineGadget = reservation.ValentineGadget,
                WantsFinisherPhoto = reservation.WantsFinisherPhoto,
            };

            await collection.InsertOneAsync(valentineRace);
        }

        async Task<List<ReservationBase>> IReservationService.Get(string userId)
        {
            int id = int.Parse(userId);
            string collectionName = "reservations";

            var collection = _reservationAccess.ConnectToMongo<ReservationBase>(collectionName);

            var results = await collection.AsQueryable()
                .Where(r => r.UserId == id)
                .ToListAsync();

            return results;
        }
    }
}
