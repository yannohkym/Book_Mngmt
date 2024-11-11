using Book_Management.Data;
using Book_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Book_Management.Controllers
{
    public class CartItemController : Controller
    {
        private readonly AppDbContext _context;

        public CartItemController(AppDbContext appcontext)
        {
            _context = appcontext;
        }

        public async Task<IActionResult> Index()
        {
            var cartList = _context.Cartitem
               .Include(c => c.Books);

            return View(await cartList.ToListAsync());
        }

        public IActionResult Create()
        {
            // ViewData["Id"] = new SelectList(_context.Cartitem, "CartId ", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryName,Description")] CartItem cart)
        {
            _context.Add(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            //check
            if (id == null)
            {
                return NotFound();
            }
            var cartItem = await _context.Cartitem.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            //ViewData["Id"] = new SelectList(_context.Cartitem, "CartId ", "CategoryName", book.Id);
            return View(cartItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CategoryName,Description")] CartItem cart)
        {
            try
            {
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound();
            }


            return RedirectToAction(nameof(Index));
            ViewData["CartId"] = new SelectList(_context.Cartitem, "CartId ", "CategoryName");
            return View(cart);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItem = await _context.Cartitem.FindAsync(id);
             
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Cart = await _context.Cartitem.FindAsync(id);
            _context.Cartitem.Remove(Cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
