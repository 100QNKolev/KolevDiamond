using KolevDiamond.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KolevDiamond.Web.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "CartItems";

        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(ProductIndexServiceModel item)
        {
            var cartItems = GetCartItems();

            bool itemExists = cartItems.Any(i => i.Id == item.Id && i.Name == item.Name);

            if (!itemExists)
            {
                cartItems.Add(item);
                SaveCartItems(cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int Id, string name)
        {
            var cartItems = GetCartItems();
            var itemToRemove = cartItems.Find(i => i.Id == Id && i.Name == name);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItems(cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        private List<ProductIndexServiceModel> GetCartItems()
        {
            var json = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(json))
                return new List<ProductIndexServiceModel>();

            return JsonSerializer.Deserialize<List<ProductIndexServiceModel>>(json)
                ?? new List<ProductIndexServiceModel>();
        }

        private void SaveCartItems(List<ProductIndexServiceModel> cartItems)
        {
            var json = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString(CartSessionKey, json);
        }
    }
}
