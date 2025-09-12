using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces;

namespace SportReserve_ApiGateway.Validators
{
    public class HttpResponseValidator : IHttpResponseValidator
    {
        public void ThrowIfResponseIsNull(HttpResponseMessage? response)
        {
            if(response == null)
            {
                throw new HttpResponseNullException("Response cannot be null.");
            }
        }
    }
}
