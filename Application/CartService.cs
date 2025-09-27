using Domain.Entities;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(int userId, int productId)
        {
            var cartItem = await _cartRepository.GetCartAsync(userId, productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
                await _cartRepository.UpdateCartAsync(cartItem);
            }
            else
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };

                await _cartRepository.AddCartAsync(cartItem);
            }
        }
    }
}
