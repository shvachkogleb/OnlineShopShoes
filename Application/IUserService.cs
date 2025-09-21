using Domain.Entities;

namespace Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user);
        Task<bool> LoginUserAsync(User user);
    }
}
