using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using OnlineShop.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> GetCartAsync(int userId, int productId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);
        }

        public async Task AddCartAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetAllCartItemsAsync(int userId)
        {
            var userCart = await _context.CartItems
                       .Where(ci => ci.UserId == userId)
                       .Include(ci => ci.Product)
                       .ToListAsync();
            return userCart;
        }

        public async Task<int> CartCountAsync(int userId)
        {
             return await _context.CartItems
            .Where(ci => ci.UserId == userId)
            .SumAsync(ci => ci.Quantity);
        }
    }
}
