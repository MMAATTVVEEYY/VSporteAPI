using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSporte.Core.Abstract;
using VSporteAPI.Entities;

namespace VSporteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService clubService;

        public ClubController(IClubService clubService)
        {
            this.clubService = clubService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetClubById(int id)
        {
            return Ok(await clubService.GetClubById(id));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllClubs()
        {
            return Ok(await clubService.GetAllClubs());

        }

        [HttpPost]
        public async Task<IActionResult> AddClub(Club club)
        {
            var result = await clubService.AddClub(club);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Club with");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClubById(int id)
        {
            var result = await clubService.DeleteClubById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No such club with id = {id}");
        }

        

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateClub(Club club)
        {
            var result = await clubService.UpdateClub(club);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No such club with id = {club.Id}");
        }
    }
}
