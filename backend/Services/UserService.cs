using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriApp.DTOs;
using NutriApp.DTOs.Users;
using NutriApp.Models.Users;
using NutriApp.Repositories;

namespace NutriApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => u.ToDTO());
        }

        public async Task<UserDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user?.ToDTO();
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                Username = userDto.Username,
                Role = Enum.Parse<UserRole>(userDto.Role),
                CreatedDate = DateTime.UtcNow
            };

            var createdUser = await _userRepository.CreateUserAsync(user);
            return createdUser.ToDTO();
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userDto.Id);
            if (user == null) return;

            user.Username = userDto.Username;
            user.Role = Enum.Parse<UserRole>(userDto.Role);

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
