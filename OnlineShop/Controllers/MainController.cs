using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Controllers
{
    public class MainController : Controller
    {
        private readonly AppDbContext _context;

        public MainController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MainPage()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            int cartCount = 0;
            if (userId.HasValue)
            {
                cartCount = await _context.CartItems
                    .Where(ci => ci.UserId == userId.Value)
                    .SumAsync(ci => ci.Quantity);
            }

            ViewBag.CartCount = cartCount;
            return View();
        }

    }
}
