using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models;

namespace SportReserve_ApiGateway.Helpers
{
    public class HttpResponseHelper : IHttpResponseHelper
    {
            public IActionResult? HandleErrorResponse(HttpResponseMessage response, string responseBody)
            {
                if (!response.IsSuccessStatusCode)
                {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var unauthorizedResponse = new ErrorResponseDto
                    {
                        StatusCode = (int)response.StatusCode,
                        Message = "Please log in to access this resource."
                    };
                    return new ObjectResult(unauthorizedResponse)
                    {
                        StatusCode = 401
                    };
                }

                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    var forbiddenResponse = new ErrorResponseDto
                    {
                        StatusCode = (int)response.StatusCode,
                        Message = "You don't have permission to perform this action."
                    };
                    return new ObjectResult(forbiddenResponse)
                    {
                        StatusCode = 403
                    };
                }
                else
                {
                    var errorResponse = new ErrorResponseDto
                    {
                        StatusCode = (int)response.StatusCode,
                        Message = responseBody
                    };

                    return new ObjectResult(errorResponse)
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                }
                return null;
            }
        }
    }

