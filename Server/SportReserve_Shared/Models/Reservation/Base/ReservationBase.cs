using MongoDB.Bson.Serialization.Attributes;

namespace SportReserve_Shared.Models.Reservation.Base
{
    public abstract class ReservationBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int RaceTraceId { get; set; }
    }
}