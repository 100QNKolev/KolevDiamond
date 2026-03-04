using KolevDiamond.Core.Contracts;
using KolevDiamond.Core.Contracts.InvestmentCoin;
using KolevDiamond.Core.Contracts.InvestmentDiamond;
using KolevDiamond.Core.Contracts.MetalBar;
using KolevDiamond.Core.Contracts.Necklace;
using KolevDiamond.Core.Contracts.Ring;
using KolevDiamond.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminJewelryServiceContract _adminJewelryService;
        private readonly IRingService _ringService;
        private readonly INecklaceService _necklaceService;
        private readonly IMetalBarService _metalBarService;
        private readonly IInvestmentDiamondService _investmentDiamondService;
        private readonly IInvestmentCoinService _investmentCoinService;

        public AdminController(
            IAdminJewelryServiceContract adminJewelryService,
            IRingService ringService,
            INecklaceService necklaceService,
            IMetalBarService metalBarService,
            IInvestmentDiamondService investmentDiamondService,
            IInvestmentCoinService investmentCoinService)
        {
            _adminJewelryService = adminJewelryService;
            _ringService = ringService;
            _necklaceService = necklaceService;
            _metalBarService = metalBarService;
            _investmentDiamondService = investmentDiamondService;
            _investmentCoinService = investmentCoinService;
        }

        [HttpGet("jewelry")]
        public async Task<IActionResult> GetAllJewelry([FromQuery] ProductQueryModel query)
        {
            var products = await _adminJewelryService.GetAllJewelry(query);
            return Ok(products);
        }

        [HttpDelete("jewelry/{id:int}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string productType)
        {
            switch (productType)
            {
                case "Ring":
                    var ring = await _ringService.GetByIdAsync(id);
                    if (ring == null) return NotFound();
                    await _ringService.Delete(id);
                    break;

                case "Necklace":
                    var necklace = await _necklaceService.GetByIdAsync(id);
                    if (necklace == null) return NotFound();
                    await _necklaceService.Delete(id);
                    break;

                case "MetalBar":
                    var metalBar = await _metalBarService.GetByIdAsync(id);
                    if (metalBar == null) return NotFound();
                    await _metalBarService.Delete(id);
                    break;

                case "InvestmentDiamond":
                    var diamond = await _investmentDiamondService.GetByIdAsync(id);
                    if (diamond == null) return NotFound();
                    await _investmentDiamondService.Delete(id);
                    break;

                case "InvestmentCoin":
                    var coin = await _investmentCoinService.GetByIdAsync(id);
                    if (coin == null) return NotFound();
                    await _investmentCoinService.Delete(id);
                    break;

                default:
                    return BadRequest($"Unknown product type '{productType}'.");
            }

            return Ok(new { message = $"{productType} with id {id} removed from sale." });
        }
    }
}
