namespace SportReserve_Reservations.Interfaces
{
    public interface IClientFactory
    {
        HttpClient CreateClient(string serviceName);
    }
}
