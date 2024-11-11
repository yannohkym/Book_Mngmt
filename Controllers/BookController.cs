using Book_Management.Data;
using Book_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Book_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext appcontext)
        {
            _context = appcontext;
        }

        public async  Task<IActionResult> Index()
        {
           // var bookList = _context.Books;

            var bookList = await _context.Books
                                .Include(b => b.CartItem)  // Include related CartItem
                                .ToListAsync();

            return View(bookList);
        }

        public IActionResult Create()
        {
            // Ensure `cartItems` has data
            var cartItems = _context.Cartitem?.ToList() ?? new List<CartItem>();
            ViewData["CartId"] = new SelectList(cartItems, "CartId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Price,CartId")] Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int?id)
        {
            //check if book  exists
            if (id == null) {
              return NotFound();
            }
            var book=await _context.Books.FindAsync(id);
            if (book == null) {
                return NotFound();
            }
            // Ensure `cartItems` has data
            var cartItems = _context.Cartitem?.ToList() ?? new List<CartItem>();

            // Populate ViewData["CartId"] with a SelectList, even if empty
            ViewData["CartId"] = new SelectList(cartItems, "CartId", "CategoryName");
           // ViewData["CartId"] = new SelectList(_context.Cartitem, "CartId ", "CategoryName", book.Id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Price,CartId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            try
             {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
             }
            catch (Exception ex)
                {
                    // Log the exception if needed
                    return NotFound();
                }
            // Repopulate ViewData["CartId"] in case of error to re-render the form
            ViewData["CartId"] = new SelectList(_context.Cartitem, "CartId", "CategoryName", book.CartId);
           
         
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

                return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
