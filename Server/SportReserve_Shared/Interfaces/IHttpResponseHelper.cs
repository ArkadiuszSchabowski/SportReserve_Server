using Microsoft.AspNetCore.Mvc;

namespace SportReserve_Shared.Interfaces
{
    public interface IHttpResponseHelper
    {
        void HandleErrorResponse(HttpResponseMessage response, string responseBody);
    }
}
