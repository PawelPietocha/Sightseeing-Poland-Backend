
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MountainsCrownController : ControllerBase
    {
        private readonly SightseeingContext _context;
        public MountainsCrownController(SightseeingContext context)
        {
            _context = context;
            
        }


        [HttpGet]
        public async Task<ActionResult<List<Mountain>>> GetMountains()
        {
            var mountains =  await _context.Mountains.ToListAsync();

            return mountains;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mountain>> GetMountain(int id)
        {
            var mountain = await _context.Mountains.FirstAsync(x => x.Id == id);

            return mountain;
        }
    }
}