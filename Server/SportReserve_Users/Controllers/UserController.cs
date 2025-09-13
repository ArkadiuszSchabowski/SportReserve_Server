using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Models.User;
using SportReserve_Users.Interfaces.Aggregates;

namespace SportReserve_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAggregateService _service;

        public UserController(IUserAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<GetUserDto>>> Get()
        {
            var users = await _service.Get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GetUserDto>> Get([FromRoute] int id)
        {
            var user = await _service.Get(id);
            return Ok(user);
        }

        [HttpGet("by-email")]
        [Authorize]
        public async Task<ActionResult<GetUserDto>> Get([FromQuery] string email)
        {
            var user = await _service.GetByEmail(email);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpPost("register/step1/validate")]
        public async Task<ActionResult> ValidateRegisterStepOne([FromBody] RegisterStepOneDto dto)
        {
            await _service.ValidateRegisterStepOne(dto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto dto)
        {
            var token = await _service.GenerateJwt(dto);
            return Ok(token);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _service.Remove(id);
            return NoContent();
        }
    }
}
