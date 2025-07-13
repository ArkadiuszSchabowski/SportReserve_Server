using Microsoft.AspNetCore.Mvc;
using SportReserve_Shared.Models.User;
using SportReserve_Shared.Models.Workout;
using SportReserve_Workouts.Interfaces.Aggregates;

namespace SportReserve_Workouts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceAggregateService _service;
        public RaceController(IRaceAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetRaceDto>>> Get()
        {
            var workouts = await _service.Get();
            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRaceDto>> Get([FromRoute] int id)
        {
            var workout = await _service.Get(id);
            return Ok(workout);
        }

        [HttpGet("name")]
        public async Task<ActionResult<GetRaceDto>> Get([FromQuery] string name)
        {
            var race = await _service.GetByName(name);
            return Ok(race);
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] AddRaceDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _service.Remove(id);
            return NoContent();
        }
    }
}
