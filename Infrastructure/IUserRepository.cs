using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
