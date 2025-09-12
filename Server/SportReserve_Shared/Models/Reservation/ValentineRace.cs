using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportReserve_Shared.Models.Reservation
{
    public class ValentineRace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int RaceTraceId { get; set; }
        public string ValentineGadget { get; set; } = string.Empty;

        public string RunType = string.Empty;
        public bool WantsFinisherPhoto { get; set; } = false;
    }
}
