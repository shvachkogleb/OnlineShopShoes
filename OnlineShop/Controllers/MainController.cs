using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Controllers
{
    public class MainController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICartRepository _cartRepository;

        public MainController(AppDbContext context, ICartRepository cartRepository)
        {
            _context = context;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> MainPage()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            int cartCount = 0;

            cartCount = await _cartRepository.CartCountAsync(userId.Value);

            ViewBag.CartCount = cartCount;
            return View();
        }

    }
}
