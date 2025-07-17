using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SportReserve_ApiGateway.Interfaces;
using SportReserve_Shared.Models.Race;
using System.Text.Json;

namespace SportReserve_ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly JsonSerializerOptions _jsonOptions;
        public RaceController(IHttpClientFactory httpClientFactory, IHttpResponseHelper httpResponseHelper, IHttpResponseValidator httpResponseValidator, IOptions<JsonOptions> jsonOptions)
        {
            _httpClientFactory = httpClientFactory;
            _httpResponseHelper = httpResponseHelper;
            _httpResponseValidator = httpResponseValidator;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [HttpGet()]
        public async Task<ActionResult<List<GetRaceDto>>> GetRaces()
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var response = await client.GetAsync("");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            List<GetRaceDto>? races = JsonSerializer.Deserialize<List<GetRaceDto>>(responseBody, _jsonOptions);

            return Ok(races);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRaceDto>> GetRace([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var response = await client.GetAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            GetRaceDto? race = JsonSerializer.Deserialize<GetRaceDto>(responseBody, _jsonOptions);

            return Ok(race);
        }

        [HttpGet("by-name")]
        public async Task<ActionResult<GetRaceDto>> GetRace([FromQuery] string name)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var query = new Dictionary<string, string?>()
            {
                ["name"] = name
            };

            var url = QueryHelpers.AddQueryString("name", query);

            var response = await client.GetAsync(url);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await response.Content.ReadFromJsonAsync<GetRaceDto>(_jsonOptions);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddRace([FromBody] AddRaceDto dto)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var response = await client.PostAsJsonAsync("add", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remove([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var response = await client.DeleteAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            return NoContent();
        }
    }
}
