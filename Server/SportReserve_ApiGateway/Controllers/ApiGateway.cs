using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SportReserve_Shared.Models.User;
using System.Text.Json;

namespace SportReserve_ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;
        public ApiGatewayController(IHttpClientFactory httpClientFactory, IOptions<JsonOptions> jsonOptions)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, new
                {
                    details = errorContent
                });
            }

            var stringJson = await response.Content.ReadAsStringAsync();

            List<GetUserDto>? users = JsonSerializer.Deserialize<List<GetUserDto>>(stringJson, _jsonOptions);

            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.GetAsync($"{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, new
                {
                    details = errorContent
                });
            }

            var stringJson = await response.Content.ReadAsStringAsync();

            GetUserDto? user = JsonSerializer.Deserialize<GetUserDto>(stringJson, _jsonOptions);

            return Ok(user);
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult<string>> Remove([FromRoute] int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.DeleteAsync($"{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, new
                {
                    details = errorContent
                });
            }

            return NoContent();
        }

        [HttpPost("users/register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("register", dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, new
                {
                    details = errorContent
                });
            }

            return Ok();
        }

        [HttpPost("users/login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var response = await client.PostAsJsonAsync("login", dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, new
                {
                    details = errorContent
                });
            }

            var token = await response.Content.ReadAsStringAsync();

            return Ok(token);
        }

        [HttpGet("users/by-email")]
        public async Task<ActionResult<GetUserDto>> GetUser([FromQuery] string email)
        {
            var client = _httpClientFactory.CreateClient("UserService");

            var query = new Dictionary<string, string?>()
            {
                ["email"] = email
            };

            var url = QueryHelpers.AddQueryString("email", query);

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, new
                {
                    details = errorContent
                });
            }

            var result = await response.Content.ReadFromJsonAsync<GetUserDto>(_jsonOptions);

            return Ok(result);
        }
    }
}