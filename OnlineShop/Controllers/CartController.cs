using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using Services;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartService;

        public CartController(AppDbContext context, ICartRepository cartRepository, ICartService cartService)
        {
            _context = context;
            _cartRepository = cartRepository;
            _cartService = cartService;
        }


        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            await _cartService.AddToCartAsync(userId.Value, productId);

            return RedirectToAction("MainPage", "Main");
        }

        public async Task<IActionResult> Cart() {

            int? userId = HttpContext.Session.GetInt32("UserId");

            var userCart = await _cartRepository.GetAllCartItemsAsync(userId.Value);

            ViewBag.UserCart = userCart;

            return View();
        }
    }
}
 