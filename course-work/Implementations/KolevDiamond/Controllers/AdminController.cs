using KolevDiamond.Core.Contracts;
using KolevDiamond.Core.Contracts.InvestmentCoin;
using KolevDiamond.Core.Contracts.InvestmentDiamond;
using KolevDiamond.Core.Contracts.MetalBar;
using KolevDiamond.Core.Contracts.Necklace;
using KolevDiamond.Core.Contracts.Ring;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentCoin;
using KolevDiamond.Core.Models.InvestmentDiamond;
using KolevDiamond.Core.Models.MetalBar;
using KolevDiamond.Core.Models.Necklace;
using KolevDiamond.Core.Models.Ring;
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

        [HttpPost("jewelry/ring")]
        public async Task<IActionResult> CreateRing([FromBody] RingModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _ringService.Create(model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPost("jewelry/necklace")]
        public async Task<IActionResult> CreateNecklace([FromBody] NecklaceModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _necklaceService.Create(model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPost("jewelry/metalbar")]
        public async Task<IActionResult> CreateMetalBar([FromBody] MetalBarModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _metalBarService.Create(model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPost("jewelry/investmentdiamond")]
        public async Task<IActionResult> CreateInvestmentDiamond([FromBody] InvestmentDiamondModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _investmentDiamondService.Create(model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPost("jewelry/investmentcoin")]
        public async Task<IActionResult> CreateInvestmentCoin([FromBody] InvestmentCoinModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _investmentCoinService.Create(model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpGet("jewelry/ring/{id:int}")]
        public async Task<IActionResult> GetRing(int id)
        {
            var model = await _ringService.GetByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(new RingModel
            {
                Id = id,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
                Metal = model.Metal,
                Purity = model.Purity,
                IsForSale = model.IsForSale
            });
        }

        [HttpGet("jewelry/necklace/{id:int}")]
        public async Task<IActionResult> GetNecklace(int id)
        {
            var model = await _necklaceService.GetByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(new NecklaceModel
            {
                Id = id,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
                Metal = model.Metal,
                Purity = model.Purity,
                IsForSale = model.IsForSale,
                Length = model.Length
            });
        }

        [HttpGet("jewelry/metalbar/{id:int}")]
        public async Task<IActionResult> GetMetalBar(int id)
        {
            var model = await _metalBarService.GetByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(new MetalBarModel
            {
                Id = id,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal,
                Purity = model.Purity,
                IsForSale = model.IsForSale,
                Weight = model.Weight,
                Dimensions = model.Dimensions
            });
        }

        [HttpGet("jewelry/investmentdiamond/{id:int}")]
        public async Task<IActionResult> GetInvestmentDiamond(int id)
        {
            var model = await _investmentDiamondService.GetByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(new InvestmentDiamondModel
            {
                Id = id,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
                CertifyingLaboratory = model.CertifyingLaboratory,
                Proportions = model.Proportions,
                IsForSale = model.IsForSale
            });
        }

        [HttpGet("jewelry/investmentcoin/{id:int}")]
        public async Task<IActionResult> GetInvestmentCoin(int id)
        {
            var model = await _investmentCoinService.GetByIdAsync(id);
            if (model == null) return NotFound();

            return Ok(new InvestmentCoinModel
            {
                Id = id,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal,
                Purity = model.Purity,
                Weight = model.Weight,
                Quality = model.Quality,
                Circulation = model.Circulation,
                Diameter = model.Diameter,
                LegalTender = model.LegalTender,
                Manufacturer = model.Manufacturer,
                Packaging = model.Packaging,
                IsForSale = model.IsForSale
            });
        }

        [HttpPut("jewelry/ring/{id:int}")]
        public async Task<IActionResult> UpdateRing(int id, [FromBody] RingModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _ringService.Update(id, model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPut("jewelry/necklace/{id:int}")]
        public async Task<IActionResult> UpdateNecklace(int id, [FromBody] NecklaceModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _necklaceService.Update(id, model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPut("jewelry/metalbar/{id:int}")]
        public async Task<IActionResult> UpdateMetalBar(int id, [FromBody] MetalBarModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _metalBarService.Update(id, model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPut("jewelry/investmentdiamond/{id:int}")]
        public async Task<IActionResult> UpdateInvestmentDiamond(int id, [FromBody] InvestmentDiamondModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _investmentDiamondService.Update(id, model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [HttpPut("jewelry/investmentcoin/{id:int}")]
        public async Task<IActionResult> UpdateInvestmentCoin(int id, [FromBody] InvestmentCoinModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, errors });
            }

            try
            {
                await _investmentCoinService.Update(id, model);
                return Ok(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }
    }
}
