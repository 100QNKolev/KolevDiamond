using KolevDiamond.Core.Contracts.Necklace;
using KolevDiamond.Core.Models.Necklace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NecklacesController : ControllerBase
    {
        private readonly INecklaceService _necklaceService;

        public NecklacesController(INecklaceService necklaceService)
        {
            _necklaceService = necklaceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] decimal? priceFilter, [FromQuery] int currentPage = 1, [FromQuery] int productsPerPage = 10)
        {
            var result = await _necklaceService.GetFilteredNecklacesAsync(priceFilter, currentPage, productsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var necklace = await _necklaceService.GetByIdAsync(id);
            if (necklace == null)
                return NotFound();

            return Ok(new NecklaceDetailsServiceModel
            {
                Id = necklace.Id,
                Name = necklace.Name,
                ImagePath = necklace.ImagePath,
                Price = necklace.Price,
                Metal = necklace.Metal,
                Carats = necklace.Carats,
                Colour = necklace.Colour,
                Clarity = necklace.Clarity,
                Cut = necklace.Cut,
                Purity = necklace.Purity,
                Length = necklace.Length
            });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([FromBody] NecklaceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _necklaceService.Create(model);
            return Ok(new { message = "Necklace created successfully." });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, [FromBody] NecklaceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _necklaceService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _necklaceService.Update(id, model);
            return Ok(new { message = "Necklace updated successfully." });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _necklaceService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _necklaceService.Delete(id);
            return Ok(new { message = "Necklace removed from sale." });
        }
    }
}
