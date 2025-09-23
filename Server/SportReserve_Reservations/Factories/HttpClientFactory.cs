using SportReserve_Reservations.Interfaces;

namespace SportReserve_Reservations.Factories
{
    public class HttpClientFactory : IClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient CreateClient(string serviceName)
        {
            return _httpClientFactory.CreateClient(serviceName);
        }
    }
}
