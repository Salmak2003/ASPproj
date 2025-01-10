using ASP_Project_2.Data;
using ASPproj.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Project_2.controllers
{
    public class AccountController : Controller
    {
        private readonly ASP_Project_2Context _context;

        public AccountController(ASP_Project_2Context context)
        {
            _context = context;
        }

        public static Customer CurrentCustomer { get; private set; }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Email == email && c.Password == password);

            if (customer != null)
            {
                CurrentCustomer = customer;
                return RedirectToAction("Index", "Items");
            }

            ViewBag.ErrorMessage = "Invalid login credentials.";
            return View();
        }

        public IActionResult Logout()
        {
            CurrentCustomer = null;
            return RedirectToAction("Login");
        }
    }

}
