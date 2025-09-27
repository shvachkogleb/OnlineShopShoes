using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ICartRepository
    {
        Task<CartItem> GetCartAsync(int userId, int productId);
        Task AddCartAsync(CartItem cartItem);
        Task UpdateCartAsync(CartItem cartItem);
        Task<List<CartItem>> GetAllCartItemsAsync(int userId);
        Task<int> CartCountAsync(int userId);
    }
}
