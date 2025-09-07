using MongoDB.Driver;

namespace SportReserve_Reservations.Interfaces
{
    public interface IReservationAccess
    {
        IMongoCollection<T> ConnectToMongo<T>(string collectionName);
    }
}
