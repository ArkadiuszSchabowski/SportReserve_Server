using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportReserve_Reservations.Models
{
    public class ReservationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }
}
