using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.User;
using System.Text.Json;

namespace SportReserve_ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpResponseHelper _httpResponseHelper;
        private readonly IHttpResponseValidator _httpResponseValidator;
        private readonly JsonSerializerOptions _jsonOptions;
        public UserController(IHttpClientFactory httpClientFactory, IHttpResponseHelper httpResponseHelper, IHttpResponseValidator httpResponseValidator, IOptions<JsonOptions> jsonOptions)
        {
            _httpClientFactory = httpClientFactory;
            _httpResponseHelper = httpResponseHelper;
            _httpResponseValidator = httpResponseValidator;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromHeader(Name = "Authorization")] string? authorizationHeader)
        {
            var client = _httpClientFactory.CreateClient("UserService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.GetAsync("");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            List<GetUserDto>? users = JsonSerializer.Deserialize<List<GetUserDto>>(responseBody, _jsonOptions);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.GetAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            GetUserDto? user = JsonSerializer.Deserialize<GetUserDto>(responseBody, _jsonOptions);

            return Ok(user);
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetUser([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromQuery] string email)
        {
            var client = _httpClientFactory.CreateClient("UserService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var query = new Dictionary<string, string?>()
            {
                ["email"] = email
            };

            var url = QueryHelpers.AddQueryString("by-email", query);

            var response = await client.GetAsync(url);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            var result = await response.Content.ReadFromJsonAsync<GetUserDto>(_jsonOptions);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("register", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return Ok();
        }

        [HttpPost("register/step1/validate")]
        public async Task<IActionResult> ValidateRegisterStepOne([FromBody] RegisterStepOneDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("register/step1/validate", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("login", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return new ContentResult
            {
                Content = responseBody,
                StatusCode = (int)response.StatusCode,
                ContentType = "application/json"
            };
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromHeader(Name = "Authorization")] string? authorizationHeader, [FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");
            client.DefaultRequestHeaders.Add("Authorization", $"{authorizationHeader}");

            var response = await client.DeleteAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            _httpResponseHelper.HandleErrorResponse(response, responseBody);

            return NoContent();
        }
    }
}
