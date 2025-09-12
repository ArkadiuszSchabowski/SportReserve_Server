using Microsoft.AspNetCore.Mvc;

namespace SportReserve_Shared.Interfaces
{
    public interface IHttpResponseHelper
    {
        ActionResult? HandleErrorResponse(HttpResponseMessage response, string responseBody);
    }
}
