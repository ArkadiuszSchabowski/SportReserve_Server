using MongoDB.Driver;
using SportReserve_Reservations.Interfaces;

namespace SportReserve_Reservations.DataAccess
{
    public class ReservationAccess : IReservationAccess
    {
        public string connectionString = "mongodb://127.0.0.1:27017";
        public string databaseName = "reservationDb";

        public IMongoCollection<T> ConnectToMongo<T>(string collectionName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collectionName);
        }
    }
}
