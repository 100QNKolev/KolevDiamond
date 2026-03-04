using Microsoft.AspNetCore.Mvc;
using KolevDiamond.Web.Models;

namespace KolevDiamond.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
                return View("Error404");

            if (statusCode == 500)
                return View("Error500");

            return View();
        }
    }
}
