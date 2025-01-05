using NutriApp.Models;

namespace NutriApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string email);
        Task<User> CreateUser(User user);
        Task<User?> GetUserByEmail(string email);
        Task UpdateUser(User user);
    }
}
