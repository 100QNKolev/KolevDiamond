using KolevDiamond.Web.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KolevDiamond.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _http;

        public AuthController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PostAsJsonAsync("api/auth/login", new
            {
                model.Email,
                model.Password
            });

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            var auth = await response.Content.ReadFromJsonAsync<AuthResponseModel>();
            if (auth == null)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error.");
                return View(model);
            }

            await SignInUser(auth);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _http.PostAsJsonAsync("api/auth/register", new
            {
                model.Email,
                model.Password,
                model.ConfirmPassword
            });

            if (!response.IsSuccessStatusCode)
            {
                var errors = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
                if (errors != null)
                {
                    foreach (var error in errors)
                        ModelState.AddModelError(string.Empty, error);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed.");
                }
                return View(model);
            }

            var auth = await response.Content.ReadFromJsonAsync<AuthResponseModel>();
            if (auth == null)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error.");
                return View(model);
            }

            await SignInUser(auth);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(AuthResponseModel auth)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, auth.Email),
                new(ClaimTypes.Name, auth.Email),
                new("jwt", auth.Token)
            };

            foreach (var role in auth.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                });
        }
    }
}
