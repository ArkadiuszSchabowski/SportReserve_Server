using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Pagination;
using SportReserve_Shared.Models.Race;
using SportReserve_Shared.Models.Reservation;
using SportReserve_Shared.Models.Reservation.Add;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Reservations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationAccess _reservationAccess;
        private readonly IClientFactory _clientFactory;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly IAnimalShelterRaceReservationValidator _animalShelterRaceReservationValidator;
        private readonly IValentineRaceReservationValidator _valentineRaceReservationValidator;
        private readonly ILondonHalfMarathonRaceReservationValidator _londonHalfMarathonRaceReservationValidator;

        public ReservationService(IReservationAccess reservationAccess, IClientFactory clientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper, IAnimalShelterRaceReservationValidator animalShelterRaceReservationValidator, IValentineRaceReservationValidator valentineRaceReservationValidator, ILondonHalfMarathonRaceReservationValidator londonHalfMarathonRaceReservationValidator)
        {
            _reservationAccess = reservationAccess;
            _clientFactory = clientFactory;
            _httpResponseValidator = httpResponseValidator;
            _httpResponseHelper = httpResponseHelper;
            _animalShelterRaceReservationValidator = animalShelterRaceReservationValidator;
            _valentineRaceReservationValidator = valentineRaceReservationValidator;
            _londonHalfMarathonRaceReservationValidator = londonHalfMarathonRaceReservationValidator;
        }
        public async Task AddAnimalShelterRace(AddAnimalShelterRace reservation, string userIdFromToken)
        {
            string collectionName = "reservations";
            var userId = reservation.UserId.ToString();

            var raceClient = _clientFactory.CreateClient("RaceService");
            var raceTraceClient = _clientFactory.CreateClient("RaceTraceService");

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

            _animalShelterRaceReservationValidator.ValidateAnimalShelterRaceReservation(getRaceDto!, getRaceTraceDto!, userId, userIdFromToken);

            var collection = _reservationAccess.ConnectToMongo<AnimalShelterRace>(collectionName);

            var animalShelterRace = new AnimalShelterRace()
            {
                Id = reservation.Id,
                DogSize = reservation.DogSize,
                DonationAmount = reservation.DonationAmount,
                EmergencyContact = reservation.EmergencyContact,
                RaceId = getRaceDto!.Id,
                RaceName = getRaceDto.Name,
                RaceTraceId = getRaceTraceDto!.Id,
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
            var userId = reservation.UserId.ToString();

            var raceClient = _clientFactory.CreateClient("RaceService");
            var raceTraceClient = _clientFactory.CreateClient("RaceTraceService");

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

            _londonHalfMarathonRaceReservationValidator.ValidateLondonHalfMarathonRaceReservation(getRaceDto!, getRaceTraceDto!, userId, userIdFromToken);

            var collection = _reservationAccess.ConnectToMongo<LondonHalfMarathonRace>(collectionName);

            var londonHalfMarathonRace = new LondonHalfMarathonRace()
            {
                Id = reservation.Id,
                MedalGratification = reservation.MedalGratification,
                TeamName = reservation.TeamName,
                TShirtSize = reservation.TShirtSize,
                RaceId = getRaceDto!.Id,
                RaceName = getRaceDto.Name,
                RaceTraceId = getRaceTraceDto!.Id,
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
            var userId = reservation.UserId.ToString();

            var raceClient = _clientFactory.CreateClient("RaceService");
            var raceTraceClient = _clientFactory.CreateClient("RaceTraceService");

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

            _valentineRaceReservationValidator.ValidateValentineRaceReservation(getRaceDto!, getRaceTraceDto!, userId, userIdFromToken);

            var collection = _reservationAccess.ConnectToMongo<ValentineRace>(collectionName);

            var valentineRace = new ValentineRace()
            {
                Id = reservation.Id,
                RaceId = getRaceDto!.Id,
                RaceName = getRaceDto!.Name,
                RaceTraceId = getRaceTraceDto!.Id,
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

        async Task<PaginationResult<ReservationBase>> IReservationService.Get(string userId, PaginationDto dto)
        {
            int id = int.Parse(userId);
            string collectionName = "reservations";

            var collection = _reservationAccess.ConnectToMongo<ReservationBase>(collectionName);

            var totalCounts = await collection.AsQueryable().Where(r => r.UserId == id).CountAsync();

            var results = await collection.AsQueryable()
                .Where(r => r.UserId == id)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToListAsync();

            var result = new PaginationResult<ReservationBase>
            {
                Results = results,
                TotalCount = totalCounts
            };

            return result;
        }
    }
}
