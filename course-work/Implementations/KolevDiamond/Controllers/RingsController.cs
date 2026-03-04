using KolevDiamond.Core.Contracts.Ring;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Ring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RingsController : ControllerBase
    {
        private readonly IRingService _ringService;

        public RingsController(IRingService ringService)
        {
            _ringService = ringService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] decimal? priceFilter, [FromQuery] int currentPage = 1, [FromQuery] int productsPerPage = 10)
        {
            var result = await _ringService.GetFilteredRingsAsync(priceFilter, currentPage, productsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ring = await _ringService.GetByIdAsync(id);
            if (ring == null)
                return NotFound();

            return Ok(new RingDetailsServiceModel
            {
                Id = ring.Id,
                Name = ring.Name,
                ImagePath = ring.ImagePath,
                Price = ring.Price,
                Metal = ring.Metal,
                Carats = ring.Carats,
                Colour = ring.Colour,
                Clarity = ring.Clarity,
                Cut = ring.Cut,
                Purity = ring.Purity
            });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([FromBody] RingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ringService.Create(model);
            return Ok(new { message = "Ring created successfully." });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, [FromBody] RingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _ringService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _ringService.Update(id, model);
            return Ok(new { message = "Ring updated successfully." });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _ringService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _ringService.Delete(id);
            return Ok(new { message = "Ring removed from sale." });
        }
    }
}
