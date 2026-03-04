using KolevDiamond.Core.Extensions;
using KolevDiamond.Core.Models;
using KolevDiamond.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Web.Controllers
{
    public class RingController : Controller
    {
        private readonly RingApiService _ringService;

        public RingController(RingApiService ringService)
        {
            _ringService = ringService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await _ringService.GetAllAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage);

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = model.ProductType ?? "Ring";

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var model = await _ringService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            if (model.GetInformation() != information)
                return NotFound();

            return View(model);
        }
    }
}
