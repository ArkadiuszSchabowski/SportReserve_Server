using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SportReserve_ApiGateway.Interfaces;
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

        [HttpGet()]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.GetAsync("");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            List<GetUserDto>? users = JsonSerializer.Deserialize<List<GetUserDto>>(responseBody, _jsonOptions);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.GetAsync($"{id}");

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            GetUserDto? user = JsonSerializer.Deserialize<GetUserDto>(responseBody, _jsonOptions);

            return Ok(user);
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<GetUserDto>> GetUser([FromQuery] string email)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var query = new Dictionary<string, string?>()
            {
                ["email"] = email
            };

            var url = QueryHelpers.AddQueryString("by-email", query);

            var response = await client.GetAsync(url);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await response.Content.ReadFromJsonAsync<GetUserDto>(_jsonOptions);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("register", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            var actionResult = _httpResponseHelper.HandleErrorResponse(response, responseBody);

            if (actionResult != null)
            {
                return actionResult;
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("login", dto);

            _httpResponseValidator.ThrowIfResponseIsNull(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ObjectResult(responseBody)
                {
                    StatusCode = (int)response.StatusCode,
                    ContentTypes = { "application/json" }
                };
            }

            return new ContentResult
            {
                Content = responseBody,
                StatusCode = (int)response.StatusCode,
                ContentType = "application/json"
            };
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remove([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");

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
