using KolevDiamond.Core.Extensions;
using KolevDiamond.Core.Models;
using KolevDiamond.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Web.Controllers
{
    public class MetalBarController : Controller
    {
        private readonly MetalBarApiService _metalBarService;

        public MetalBarController(MetalBarApiService metalBarService)
        {
            _metalBarService = metalBarService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await _metalBarService.GetAllAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage);

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = model.ProductType ?? "MetalBar";

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var model = await _metalBarService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            if (model.GetInformation() != information)
                return NotFound();

            return View(model);
        }
    }
}
