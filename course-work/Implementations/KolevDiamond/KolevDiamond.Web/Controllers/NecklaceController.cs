using KolevDiamond.Core.Extensions;
using KolevDiamond.Core.Models;
using KolevDiamond.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Web.Controllers
{
    public class NecklaceController : Controller
    {
        private readonly NecklaceApiService _necklaceService;

        public NecklaceController(NecklaceApiService necklaceService)
        {
            _necklaceService = necklaceService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = await _necklaceService.GetAllAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage);

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = model.ProductType ?? "Necklace";

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            var model = await _necklaceService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            if (model.GetInformation() != information)
                return NotFound();

            return View(model);
        }
    }
}
