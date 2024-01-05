using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifictions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MountainsCrownController : BaseApiController
    {
        private readonly IGenericRepository<Mountain> _mountainsRepository;
        private readonly IGenericRepository<Voivodeship> _voivodeshipRepository;
        private readonly IGenericRepository<MountainsRange> _mountainRangeRepository;
        private readonly IMapper _mapper;

        public MountainsCrownController
        (
            IGenericRepository<Mountain> mountainsRepository,
            IGenericRepository<Voivodeship> voivodeshipRepository,
            IGenericRepository<MountainsRange> mountainRangeRepository,
            IMapper mapper
            )
        {
            _mountainsRepository = mountainsRepository;
            _voivodeshipRepository = voivodeshipRepository;
            _mountainRangeRepository = mountainRangeRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<MountainDto>>> GetMountains(
            [FromQuery] MountainsSpecParams mountainsParams)
        {
            var spec = new MountainWithMountainRangeAndVoivodeshipSpecification(mountainsParams);

            var countSpec = new MountWithFiltersForCountSpecification(mountainsParams);

            var totalItems = await _mountainsRepository.CountAsync(countSpec);

            var mountains = await _mountainsRepository.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Mountain>, IReadOnlyList<MountainDto>>(mountains); 

            return Ok(new Pagination<MountainDto>(mountainsParams.PageIndex, mountainsParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MountainDto>> GetMountain(int id)
        {
            var spec = new MountainWithMountainRangeAndVoivodeshipSpecification(id);
            var mountain = await _mountainsRepository.GetEntityWithSpec(spec);

            if(mountain == null )
            {
                return NotFound(new APIResponse(404));
            }

            return _mapper.Map<Mountain, MountainDto>(mountain);
        }

        [HttpGet("voivodeships")]
        public async Task<ActionResult<List<Voivodeship>>> GetVoivodeships()
        {
            var voivodeships = await _voivodeshipRepository.ListAllAsync();

            return Ok(voivodeships);
        }

        [HttpGet("voivodeships/{id}")]
        public async Task<ActionResult<Voivodeship>> GetVoivodeship(int id)
        {
            var voivodeship = await _voivodeshipRepository.GetByIdAsync(id);

            if(voivodeship == null )
            {
                return NotFound(new APIResponse(404));
            }

            return Ok(voivodeship);
        }

        [HttpGet("mountainsRanges")]
        public async Task<ActionResult<List<MountainsRange>>> GetMountainsRanges()
        {
            var mountainsRanges = await _mountainRangeRepository.ListAllAsync();

            return Ok(mountainsRanges);
        }

        [HttpGet("mountainsRanges/{id}")]
        public async Task<ActionResult<MountainsRange>> GetMountainsRange(int id)
        {
            var mountainsRange = await _mountainRangeRepository.GetByIdAsync(id);

            if(mountainsRange == null )
            {
                return NotFound(new APIResponse(404));
            }

            return Ok(mountainsRange);
        }

        [HttpGet("test")]
        public ActionResult GetTest()
        {
            Mountain thing = null;
            var thingToReturn = thing.ToString();
            return Ok();
        }
}
}