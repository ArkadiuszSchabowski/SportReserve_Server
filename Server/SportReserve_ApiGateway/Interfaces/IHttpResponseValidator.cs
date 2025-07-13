namespace SportReserve_ApiGateway.Interfaces
{
    public interface IHttpResponseValidator
    {
        void ThrowIfResponseIsNull(HttpResponseMessage? response);
    }
}
