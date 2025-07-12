using Microsoft.AspNetCore.Mvc;

namespace SportReserve_ApiGateway.Interfaces
{
    public interface IHttpResponseHelper
    {
        ActionResult? HandleErrorResponse(HttpResponseMessage response, string responseBody);
    }
}
