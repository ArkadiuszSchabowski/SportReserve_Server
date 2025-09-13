using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.Pagination;
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
        public RaceController(IHttpClientFactory httpClientFactory, IHttpResponseValidator httpResponseValidator, IHttpResponseHelper httpResponseHelper, IOptions<JsonOptions> jsonOptions)
        {
            _httpClientFactory = httpClientFactory;
            _httpResponseHelper = httpResponseHelper;
            _httpResponseValidator = httpResponseValidator;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationDto dto)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var requestUrl = QueryHelpers.AddQueryString("", new Dictionary<string, string?>
            {
                { "pageNumber", dto.PageNumber.ToString() },
                { "pageSize", dto.PageSize.ToString() }
            });

            var response = await client.GetAsync(requestUrl);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            PaginationResult<GetRaceDto>? result = JsonSerializer.Deserialize<PaginationResult<GetRaceDto>>(responseBody, _jsonOptions);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRace([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var response = await client.GetAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            GetRaceDto? race = JsonSerializer.Deserialize<GetRaceDto>(responseBody, _jsonOptions);

            return Ok(race);
        }

        [HttpGet("by-name")]
        public async Task<IActionResult> GetRace([FromQuery] string name)
        {
            var client = _httpClientFactory.CreateClient("RaceService");

            var query = new Dictionary<string, string?>()
            {
                ["name"] = name
            };

            var url = QueryHelpers.AddQueryString("by-name", query);

            var response = await client.GetAsync(url);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            var result = await response.Content.ReadFromJsonAsync<GetRaceDto>(_jsonOptions);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRace([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromBody] AddRaceDto dto)
        {
            var client = _httpClientFactory.CreateClient("RaceService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.PostAsJsonAsync("", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRace([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromBody] AddRaceDto dto, [FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.PutAsJsonAsync($"{id}", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("RaceService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.DeleteAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return NoContent();
        }
    }
}
