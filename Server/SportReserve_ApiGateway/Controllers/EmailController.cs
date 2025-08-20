using Microsoft.AspNetCore.Mvc;
using SportReserve_ApiGateway.Interfaces;
using SportReserve_Shared.Models.Email;

namespace SportReserve_ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly IHttpResponseHelper _httpResponseHelper;

        public EmailController(IHttpClientFactory httpClientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper)
        {
            _httpClientFactory = httpClientFactory;
            _httpResponseValidator = httpResponseValidator;
            _httpResponseHelper = httpResponseHelper;
        }
        [HttpPost("send")]
        public async Task<ActionResult> SendEmailToAdmin([FromBody] SendEmailToAdminDto dto)
        {
            var client = _httpClientFactory.CreateClient("EmailService");

            var response = await client.PostAsJsonAsync("send", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            return Ok();
        }
    }
}
