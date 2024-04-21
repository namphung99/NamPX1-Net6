using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NamPX.API.Repositories;

namespace NamPX.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            // Fetch data from DB - domain walks
            var walksDomain = await walkRepository.GetAllAsync();

            // Convert domain walks to DTO Walks
            var walksDTO = mapper.Map<List<Models.DTO.Walks>>(walksDomain);

            // Return response
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            // Get from DB
            var walk = await walkRepository.GetAsync(id);

            if(walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walks>(walk);
            return Ok(walkDTO);
        }
    }
}
