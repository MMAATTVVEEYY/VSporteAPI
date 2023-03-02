using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSporte.Core.Abstract;
using VSporteAPI.Data;
using VSporteAPI.Entities;

namespace VSporteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet("id")]
        public async Task <IActionResult> GetPlayerById(int id)
        {
            var player = await playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok (player);
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            return Ok(await playerService.GetAllPlayers());

        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(Player player)
        {
            return Ok(await playerService.AddPlayer(player));

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayerById(int id)
        {
            var result= await playerService.DeletePlayerById(id);
            if (result!= null)
            {
                return Ok(result);
            }
            return NotFound($"No such player with id = {id}");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PlayerAddToClub(int PlayerId, int ClubId)
        {
            var result =await playerService.PlayerAddToClub(PlayerId, ClubId);
            if (result== false)
            {
                return BadRequest("Player is already in the club");
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PlayerRemoveFromClub(int PlayerId, int ClubId)
        {
            var result = await playerService.PlayerRemoveFromClub(PlayerId, ClubId);
            if (result == false)
            {
                return BadRequest("No such playerclub");
            }
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePlayer(Player player)
        {
            var result = await playerService.UpdatePlayer(player);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No such player with id = {player.Id}");
        }
    }
}
