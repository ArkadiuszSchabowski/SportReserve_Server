using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace SportReserve_Shared.Models.Reservation.Base
{
    [BsonDiscriminator(RootClass = true)]
    [JsonDerivedType(typeof(AnimalShelterRace))]
    [JsonDerivedType(typeof(ValentineRace))]
    [JsonDerivedType(typeof(LondonHalfMarathonRace))]
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