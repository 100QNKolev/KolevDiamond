using KolevDiamond.Core.Contracts.InvestmentDiamond;
using KolevDiamond.Core.Models.InvestmentDiamond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentDiamondsController : ControllerBase
    {
        private readonly IInvestmentDiamondService _investmentDiamondService;

        public InvestmentDiamondsController(IInvestmentDiamondService investmentDiamondService)
        {
            _investmentDiamondService = investmentDiamondService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] decimal? priceFilter, [FromQuery] int currentPage = 1, [FromQuery] int productsPerPage = 10)
        {
            var result = await _investmentDiamondService.GetFilteredInvestmentDiamondsAsync(priceFilter, currentPage, productsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var diamond = await _investmentDiamondService.GetByIdAsync(id);
            if (diamond == null)
                return NotFound();

            return Ok(new InvestmentDiamondDetailsServiceModel
            {
                Id = diamond.Id,
                Name = diamond.Name,
                ImagePath = diamond.ImagePath,
                Price = diamond.Price,
                Carats = diamond.Carats,
                Colour = diamond.Colour,
                Clarity = diamond.Clarity,
                Cut = diamond.Cut,
                CertifyingLaboratory = diamond.CertifyingLaboratory,
                Proportions = diamond.Proportions
            });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([FromBody] InvestmentDiamondModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _investmentDiamondService.Create(model);
            return Ok(new { message = "Investment diamond created successfully." });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, [FromBody] InvestmentDiamondModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _investmentDiamondService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _investmentDiamondService.Update(id, model);
            return Ok(new { message = "Investment diamond updated successfully." });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _investmentDiamondService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _investmentDiamondService.Delete(id);
            return Ok(new { message = "Investment diamond removed from sale." });
        }
    }
}
