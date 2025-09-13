using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Race;
using System.Text.Json;

namespace SportReserve_ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceTraceController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly JsonSerializerOptions _jsonOptions;

        public RaceTraceController(IHttpClientFactory httpClientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper, IOptions<JsonOptions> jsonOptions)
        {
            _httpClientFactory = httpClientFactory;
            _httpResponseValidator = httpResponseValidator;
            _httpResponseHelper = httpResponseHelper;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient("RaceTraceService");

            var response = await client.GetAsync("");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            List<GetRaceTraceDto>? result = JsonSerializer.Deserialize<List<GetRaceTraceDto>>(responseBody, _jsonOptions);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRaceTrace([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceTraceService");

            var response = await client.GetAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            GetRaceDto? race = JsonSerializer.Deserialize<GetRaceDto>(responseBody, _jsonOptions);

            return Ok(race);
        }

        [HttpPost]
        public async Task<IActionResult> AddRaceTrace([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromBody] AddRaceTraceDto dto)
        {
            var client = _httpClientFactory.CreateClient("RaceTraceService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.PostAsJsonAsync("", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceTraceService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.DeleteAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return NoContent();
        }
    }
}