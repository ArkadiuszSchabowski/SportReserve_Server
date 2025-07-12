using Microsoft.AspNetCore.Mvc;
using SportReserve_ApiGateway.Interfaces;

namespace SportReserve_ApiGateway.Helpers
{
    public class HttpResponseHelper : IHttpResponseHelper
    {
        public ActionResult? HandleErrorResponse(HttpResponseMessage response, string responseBody)
        {
            if (!response.IsSuccessStatusCode)
            {
                return new ObjectResult(new { details = responseBody })
                {
                    StatusCode = (int)response.StatusCode
                };
            }
            return null;
        }
    }
}
