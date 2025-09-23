using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using Domain.Entities;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (cartItem != null)
                cartItem.Quantity++;
            else
            {
                cartItem = new CartItem
                {
                    UserId = userId.Value,
                    ProductId = productId,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("MainPage", "Main");
        }
    }
}
