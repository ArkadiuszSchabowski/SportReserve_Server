using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models;

namespace SportReserve_ApiGateway.Helpers
{
    public class HttpResponseHelper : IHttpResponseHelper
    {
        public void HandleErrorResponse(HttpResponseMessage response, string responseBody)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedException("Please log in to access this resource.");
                }

                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new ForbiddenException("You don't have permission to perform this action.");
                }
                else
                {
                    throw new HttpRequestException(responseBody, null, response.StatusCode);
                }

            }
        }
    }
}
