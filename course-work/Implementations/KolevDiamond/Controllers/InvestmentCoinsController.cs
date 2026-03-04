using KolevDiamond.Core.Contracts.InvestmentCoin;
using KolevDiamond.Core.Models.InvestmentCoin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentCoinsController : ControllerBase
    {
        private readonly IInvestmentCoinService _investmentCoinService;

        public InvestmentCoinsController(IInvestmentCoinService investmentCoinService)
        {
            _investmentCoinService = investmentCoinService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] decimal? priceFilter, [FromQuery] int currentPage = 1, [FromQuery] int productsPerPage = 10)
        {
            var result = await _investmentCoinService.GetFilteredInvestmentCoinsAsync(priceFilter, currentPage, productsPerPage);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coin = await _investmentCoinService.GetByIdAsync(id);
            if (coin == null)
                return NotFound();

            return Ok(new InvestmentCoinDetailsServiceModel
            {
                Id = coin.Id,
                Name = coin.Name,
                ImagePath = coin.ImagePath,
                Price = coin.Price,
                Metal = coin.Metal,
                Weight = coin.Weight,
                Purity = coin.Purity,
                Quality = coin.Quality,
                Circulation = coin.Circulation,
                Diameter = coin.Diameter,
                LegalTender = coin.LegalTender,
                Manufacturer = coin.Manufacturer,
                Packaging = coin.Packaging
            });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([FromBody] InvestmentCoinModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _investmentCoinService.Create(model);
            return Ok(new { message = "Investment coin created successfully." });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, [FromBody] InvestmentCoinModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _investmentCoinService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _investmentCoinService.Update(id, model);
            return Ok(new { message = "Investment coin updated successfully." });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _investmentCoinService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _investmentCoinService.Delete(id);
            return Ok(new { message = "Investment coin removed from sale." });
        }
    }
}
