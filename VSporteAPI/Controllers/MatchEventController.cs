using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSporte.Core.Abstract;
using VSporteAPI.Entities;

namespace VSporteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly IMatchEventService matchEventService;

        public MatchEventController(IMatchEventService matchEventService)
        {
            this.matchEventService = matchEventService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMatchEventById(int id)
        {
            return Ok(await matchEventService.GetMatchEventById(id));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatchEvents()
        {
            return Ok(await matchEventService.GetAllMatchEvents());

        }

        [HttpPost]
        public async Task<IActionResult> AddMatchEvent(MatchEvent matchEvent)
        {
            var result = await matchEventService.AddMatchEvent(matchEvent);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("MatchEvent already exists");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMatchEventById(int id)
        {
            var result = await matchEventService.DeleteMatchEventById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No such matchEvent with id = {id}");
        }



        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMatchEvent(MatchEvent matchEvent)
        {
            var result = await matchEventService.UpdateMatchEvent(matchEvent);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No such matchEvent with id = {matchEvent.Id}");
        }
    }
}
