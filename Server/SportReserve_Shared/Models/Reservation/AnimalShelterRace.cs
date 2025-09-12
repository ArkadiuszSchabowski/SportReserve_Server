using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportReserve_Shared.Models.Reservation
{
    public class AnimalShelterRace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int RaceTraceId { get; set; }
        public string? DogSize { get; set; }
        public int? DonationAmount { get; set; }
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
