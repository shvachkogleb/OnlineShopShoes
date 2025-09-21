using Domain.Entities;
using Infrastructure.Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> LoginUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            var existing = await _userRepository.GetByEmailAsync(user.Email);
            if (existing != null)
                return false;

            await _userRepository.AddUserAsync(user);
            return true;
        }

    }
}
