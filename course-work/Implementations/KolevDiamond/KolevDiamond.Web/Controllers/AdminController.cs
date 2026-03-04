using KolevDiamond.Core.Models;
using KolevDiamond.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KolevDiamond.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly AdminApiService _adminService;

        public AdminController(AdminApiService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Jewelry([FromQuery] ProductQueryModel query)
        {
            var model = await _adminService.GetAllJewelryAsync(
                query.PriceFilter,
                query.CurrentPage,
                query.ProductsPerPage,
                query.IsForSale);

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string productType)
        {
            await _adminService.DeleteAsync(id, productType);
            return RedirectToAction(nameof(Jewelry));
        }
    }
}
