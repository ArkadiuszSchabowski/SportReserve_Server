using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportReserve_Shared.Models.Reservation.Base
{
    public class BaseRace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int RaceId { get; set; }
    }
}
