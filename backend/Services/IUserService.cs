using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutriApp.DTOs;
using NutriApp.DTOs.Users;

namespace NutriApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(Guid id);
        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(Guid id);
    }
}
