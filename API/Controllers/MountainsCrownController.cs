using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MountainsCrownController : ControllerBase
    {
        private readonly IMountainRepository _mountainRepository;
        public MountainsCrownController(IMountainRepository mountainRepository)
        {
            _mountainRepository = mountainRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Mountain>>> GetMountains()
        {
            var mountains =  await _mountainRepository.GetMountains();

            return Ok(mountains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mountain>> GetMountain(int id)
        {
            var mountain = await _mountainRepository.GetMountain(id);

            return mountain;
        }

        [HttpGet("voivodeships")]
        public async Task<ActionResult<Mountain>> GetVoivodeships()
        {
            var voivodeships = await _mountainRepository.GetVoivodeships();

            return Ok(voivodeships);
        }

        [HttpGet("mountainsRanges")]
        public async Task<ActionResult<Mountain>> GetMountainsRanges()
        {
            var mountainsRanges = await _mountainRepository.GetMountainsRanges();

            return Ok(mountainsRanges);
        }
    }
}