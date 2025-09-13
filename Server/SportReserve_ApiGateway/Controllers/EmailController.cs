using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Interfaces;
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
        public async Task<IActionResult> SendEmailToAdmin([FromBody] SendEmailToAdminDto dto)
        {
            var client = _httpClientFactory.CreateClient("EmailService");

            var response = await client.PostAsJsonAsync("send", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return Ok();
        }
    }
}
