using KolevDiamond.Core.Extensions;
using KolevDiamond.Core.Models;
using KolevDiamond.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Web.Controllers
{
    public class InvestmentDiamondController : Controller
    {
        private readonly InvestmentDiamondApiService _investmentDiamondService;

        public InvestmentDiamondController(InvestmentDiamondApiService investmentDiamondService)
        {
            _investmentDiamondService = investmentDiamondService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await _investmentDiamondService.GetAllAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage);

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = model.ProductType ?? "InvestmentDiamond";

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var model = await _investmentDiamondService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            if (model.GetInformation() != information)
                return NotFound();

            return View(model);
        }
    }
}
