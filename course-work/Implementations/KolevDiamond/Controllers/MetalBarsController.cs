using KolevDiamond.Core.Contracts.MetalBar;
using KolevDiamond.Core.Models.MetalBar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetalBarsController : ControllerBase
    {
        private readonly IMetalBarService _metalBarService;

        public MetalBarsController(IMetalBarService metalBarService)
        {
            _metalBarService = metalBarService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] decimal? priceFilter, [FromQuery] int currentPage = 1, [FromQuery] int productsPerPage = 10)
        {
            var result = await _metalBarService.GetFilteredMetalBarsAsync(priceFilter, currentPage, productsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var metalBar = await _metalBarService.GetByIdAsync(id);
            if (metalBar == null)
                return NotFound();

            return Ok(new MetalBarDetailsServiceModel
            {
                Id = metalBar.Id,
                Name = metalBar.Name,
                ImagePath = metalBar.ImagePath,
                Price = metalBar.Price,
                Metal = metalBar.Metal,
                Weight = metalBar.Weight,
                Dimensions = metalBar.Dimensions,
                Purity = metalBar.Purity
            });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([FromBody] MetalBarModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _metalBarService.Create(model);
            return Ok(new { message = "Metal bar created successfully." });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, [FromBody] MetalBarModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _metalBarService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _metalBarService.Update(id, model);
            return Ok(new { message = "Metal bar updated successfully." });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _metalBarService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _metalBarService.Delete(id);
            return Ok(new { message = "Metal bar removed from sale." });
        }
    }
}
