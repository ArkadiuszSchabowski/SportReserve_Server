namespace SportReserve_Shared.Interfaces
{
    public interface IHttpResponseValidator
    {
        void ThrowIfResponseIsNull(HttpResponseMessage? response);
    }
}
