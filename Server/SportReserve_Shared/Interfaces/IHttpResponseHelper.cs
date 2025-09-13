using Microsoft.AspNetCore.Mvc;

namespace SportReserve_Shared.Interfaces
{
    public interface IHttpResponseHelper
    {
        IActionResult? HandleErrorResponse(HttpResponseMessage response, string responseBody);
    }
}
