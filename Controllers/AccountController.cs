using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPproj.Data;
using ASPproj.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ASPproj.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Customers.FirstOrDefault(u =>
                    u.Username == model.Username || u.Email == model.Email
                );
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Username or Email already exists.");
                    return View(model);
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                var customer = new Customer
                {
                    ID = Guid.NewGuid().ToString(),
                    Username = model.Username,
                    Name = model.Name,
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                await SignInUser(customer, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _context.Customers.FirstOrDefault(u => u.Username == model.Username);
                if (
                    customer != null
                    && BCrypt.Net.BCrypt.Verify(model.Password, customer.PasswordHash)
                )
                {
                    await SignInUser(customer, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private async Task SignInUser(Customer customer, bool isPersistent)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, customer.Username),
                new Claim(ClaimTypes.NameIdentifier, customer.ID.ToString()),
                new Claim(ClaimTypes.Email, customer.Email),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent,
                ExpiresUtc = isPersistent
                    ? DateTimeOffset.UtcNow.AddDays(7)
                    : DateTimeOffset.UtcNow.AddMinutes(60),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
        }
    }
}
