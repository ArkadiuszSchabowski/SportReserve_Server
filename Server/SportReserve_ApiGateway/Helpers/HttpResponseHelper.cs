using Microsoft.AspNetCore.Mvc;
using SportReserve_ApiGateway.Interfaces;
using SportReserve_Shared.Models;

namespace SportReserve_ApiGateway.Helpers
{
    public class HttpResponseHelper : IHttpResponseHelper
    {
        public ActionResult? HandleErrorResponse(HttpResponseMessage response, string responseBody)
        {
            if (!response.IsSuccessStatusCode)
            {
                return new ObjectResult(new ErrorResponseDto
                {
                    StatusCode = (int)response.StatusCode,
                    Message = responseBody
                });
            }
            return null;
        }
    }
}
