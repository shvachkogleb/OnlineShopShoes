using Domain.Entities;
using System.Runtime.CompilerServices;

namespace Services
{
    public interface ICartService
    {
        Task AddToCartAsync(int userId, int productId);
    }
}


