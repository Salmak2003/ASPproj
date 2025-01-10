using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Project_2.Data;
using ASPproj.Models;

namespace ASP_Project_2.controllers
{
    public class CartsController : Controller
    {
        private readonly ASP_Project_2Context _context;

        public CartsController(ASP_Project_2Context context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var customerId = AccountController.CurrentCustomer.Customr_Id;

            if (customerId == null)
            {
                return View("EmptyCart");
            }

            var cart = _context.Cart
                .Where(c => c.Customr_Id == customerId)
                .Include(c => c.Cart_items)
                .ThenInclude(ci => ci.item)
                .FirstOrDefault();

            if (cart == null)
            {
                return View("EmptyCart");
            }

            return View(cart);
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.customer)
                .FirstOrDefaultAsync(m => m.Cart_Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["Customr_Id"] = new SelectList(_context.Customer, "Customr_Id", "Customr_Id");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cart_Id,Customr_Id")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customr_Id"] = new SelectList(_context.Customer, "Customr_Id", "Customr_Id", cart.Customr_Id);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["Customr_Id"] = new SelectList(_context.Customer, "Customr_Id", "Customr_Id", cart.Customr_Id);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cart_Id,Customr_Id")] Cart cart)
        {
            if (id != cart.Cart_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Cart_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customr_Id"] = new SelectList(_context.Customer, "Customr_Id", "Customr_Id", cart.Customr_Id);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.customer)
                .FirstOrDefaultAsync(m => m.Cart_Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart != null)
            {
                _context.Cart.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(string id)
        {
            return _context.Cart.Any(e => e.Cart_Id == id);
        }
    }
}
