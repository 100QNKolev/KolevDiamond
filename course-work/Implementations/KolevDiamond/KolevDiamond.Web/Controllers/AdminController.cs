using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Admin;
using KolevDiamond.Core.Models.InvestmentCoin;
using KolevDiamond.Core.Models.InvestmentDiamond;
using KolevDiamond.Core.Models.MetalBar;
using KolevDiamond.Core.Models.Necklace;
using KolevDiamond.Core.Models.Ring;
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
        public IActionResult DashBoard()
        {
            return View();
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
            query.ProductType = "Admin";

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string productType)
        {
            await _adminService.DeleteAsync(id, productType);
            return RedirectToAction(nameof(Jewelry));
        }

        [HttpGet]
        public IActionResult Add([FromQuery] AdminQueryModel query)
        {
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string productType)
        {
            object query;

            switch (productType)
            {
                case "Ring":
                    query = await _adminService.GetByIdAsync<RingModel>("ring", id);
                    ViewBag.Category = "Ring";
                    break;

                case "Necklace":
                    query = await _adminService.GetByIdAsync<NecklaceModel>("necklace", id);
                    ViewBag.Category = "Necklace";
                    break;

                case "MetalBar":
                    query = await _adminService.GetByIdAsync<MetalBarModel>("metalbar", id);
                    ViewBag.Category = "MetalBar";
                    break;

                case "InvestmentDiamond":
                    query = await _adminService.GetByIdAsync<InvestmentDiamondModel>("investmentdiamond", id);
                    ViewBag.Category = "InvestmentDiamond";
                    break;

                case "InvestmentCoin":
                    query = await _adminService.GetByIdAsync<InvestmentCoinModel>("investmentcoin", id);
                    ViewBag.Category = "InvestmentCoin";
                    break;

                default:
                    return BadRequest("Invalid product type.");
            }

            if (query == null) return BadRequest("Item not found.");

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitRingForm([FromForm] RingModel model)
        {
            var response = await _adminService.CreateAsync("ring", model);
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitNecklaceForm([FromForm] NecklaceModel model)
        {
            var response = await _adminService.CreateAsync("necklace", model);
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMetalBarForm([FromForm] MetalBarModel model)
        {
            var response = await _adminService.CreateAsync("metalbar", model);
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInvestmentDiamondForm([FromForm] InvestmentDiamondModel model)
        {
            var response = await _adminService.CreateAsync("investmentdiamond", model);
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInvestmentCoinForm([FromForm] InvestmentCoinModel model)
        {
            var response = await _adminService.CreateAsync("investmentcoin", model);
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditRing(RingModel model)
        {
            if (model.Id != null)
            {
                await _adminService.UpdateAsync("ring", (int)model.Id, model);
            }
            return RedirectToAction(nameof(Jewelry));
        }

        [HttpPost]
        public async Task<IActionResult> EditNecklace(NecklaceModel model)
        {
            if (model.Id != null)
            {
                await _adminService.UpdateAsync("necklace", (int)model.Id, model);
            }
            return RedirectToAction(nameof(Jewelry));
        }

        [HttpPost]
        public async Task<IActionResult> EditMetalBar(MetalBarModel model)
        {
            if (model.Id != null)
            {
                await _adminService.UpdateAsync("metalbar", (int)model.Id, model);
            }
            return RedirectToAction(nameof(Jewelry));
        }

        [HttpPost]
        public async Task<IActionResult> EditInvestmentDiamond(InvestmentDiamondModel model)
        {
            if (model.Id != null)
            {
                await _adminService.UpdateAsync("investmentdiamond", (int)model.Id, model);
            }
            return RedirectToAction(nameof(Jewelry));
        }

        [HttpPost]
        public async Task<IActionResult> EditInvestmentCoin(InvestmentCoinModel model)
        {
            if (model.Id != null)
            {
                await _adminService.UpdateAsync("investmentcoin", (int)model.Id, model);
            }
            return RedirectToAction(nameof(Jewelry));
        }
    }
}
