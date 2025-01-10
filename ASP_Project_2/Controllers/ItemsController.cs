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
    public class ItemsController : Controller
    {
        private readonly ASP_Project_2Context _context;

        public ItemsController(ASP_Project_2Context context)
        {
            _context = context;
        }

        // GET: Items
        public IActionResult Index(string searchName, string sortOrder)
        {
            //var items = from i in _context.Item
            //            select i;

            var items = new List<Item>
            {
                new Item { Name = "Item1", Price = 10, stock_quantity = 5 },
                new Item { Name = "Item2", Price = 20, stock_quantity = 2 }
            };

            if (!string.IsNullOrEmpty(searchName))
            {
                items = items.FindAll(i => i.Name.Contains(searchName));
            }
            if (sortOrder == "price_asc")
            {
                items.Sort((a, b) => a.Price.CompareTo(b.Price));
            }
            else if (sortOrder == "price_desc")
            {
                items.Sort((a, b) => b.Price.CompareTo(a.Price));
            }

            //if (!string.IsNullOrEmpty(searchName))
            //{
            //    items = items.Where(i => i.Name.Contains(searchName));
            //}

            //switch (sortOrder)
            //{
            //    case "price_asc":
            //        items = items.OrderBy(i => i.Price);
            //        break;
            //    case "price_desc":
            //        items = items.OrderByDescending(i => i.Price);
            //        break;
            //    default:
            //        items = items.OrderBy(i => i.Name);
            //        break;
            //}

            ViewData["SearchName"] = searchName;
            ViewData["SortOrder"] = sortOrder;

            return View(items.ToList());
        }



        // GET: Items/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Item_Id == id);
            if (item == null)
            {
                return NotFound();
            }

            ViewBag.ItemId = item.Item_Id;
            ViewBag.ItemName = item.Name;
            ViewBag.ItemPrice = item.Price;
            ViewBag.ItemStock = item.stock_quantity;

            return View(item);
        }

        // GET: Items/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Item_Id,Name,Price,stock_quantity")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Item_Id,Name,Price,stock_quantity")] Item item)
        {
            if (id != item.Item_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Item_Id))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Item_Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(string id)
        {
            return _context.Item.Any(e => e.Item_Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string itemId, int quantity)
        {
            var customerId = AccountController.CurrentCustomer.Customr_Id;
            var cart = await _context.Cart
                .Include(c => c.Cart_items)
                .FirstOrDefaultAsync(c => c.Customr_Id == customerId);

            if (cart == null)
            {
                cart = new Cart
                {
                    Cart_Id = Guid.NewGuid().ToString(),
                    Customr_Id = customerId,
                    Cart_items = new List<Cart_item>()
                };
                _context.Cart.Add(cart);
            }

            var cartItem = cart.Cart_items.FirstOrDefault(ci => ci.Item_Id == itemId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new Cart_item
                {
                    Car_Item_Id = Guid.NewGuid().ToString(),
                    Cart_Id = cart.Cart_Id,
                    Item_Id = itemId,
                    Quantity = quantity
                };
                cart.Cart_items.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
