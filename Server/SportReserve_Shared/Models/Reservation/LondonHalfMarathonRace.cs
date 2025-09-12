using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportReserve_Shared.Models.Reservation
{
    public class LondonHalfMarathonRace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int RaceTraceId { get; set; }
        public string TShirtSize { get; set; } = string.Empty;

        public string? TeamName;
        public bool MedalGratification { get; set; } = false;
    }
}
