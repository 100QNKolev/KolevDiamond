using KolevDiamond.Core.Extensions;
using KolevDiamond.Core.Models;
using KolevDiamond.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Web.Controllers
{
    public class InvestmentCoinController : Controller
    {
        private readonly InvestmentCoinApiService _investmentCoinService;

        public InvestmentCoinController(InvestmentCoinApiService investmentCoinService)
        {
            _investmentCoinService = investmentCoinService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await _investmentCoinService.GetAllAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage);

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = model.ProductType ?? "InvestmentCoin";

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var model = await _investmentCoinService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            if (model.GetInformation() != information)
                return NotFound();

            return View(model);
        }
    }
}
