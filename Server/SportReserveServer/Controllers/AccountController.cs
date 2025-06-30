using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Models;
using SportReserveServer.Interfaces.Aggregates;

namespace SportReserveServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAggregateService _service;

        public AccountController(IAccountAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> Get()
        {
            var users = await _service.Get();
            return Ok(users);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<GetUserDto>> Get([FromRoute] int id)
        {
            var user = await _service.Get(id);
            return Ok(user);
        }

        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<GetUserDto>> Get([FromQuery] string email)
        {
            var user = await _service.Get(email);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] AddUserDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto dto)
        {
            var token = await _service.GenerateJwt(dto);
            return Ok(token);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _service.Remove(id);
            return NoContent();
        }
    }
}
