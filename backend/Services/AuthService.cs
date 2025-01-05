using NutriApp.Models;
using NutriApp.Repositories.Interfaces;
using NutriApp.DTOs;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace NutriApp.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<(bool Success, Dictionary<string, string>? Errors, string? Token)> Login(LoginRequest request)
        {
            var errors = new Dictionary<string, string>();

            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                errors["non_field_errors"] = "Invalid email or password.";
                return (false, errors, null);
            }

            var token = GenerateJwtToken(user);
            return (true, null, token);
        }


        public async Task<(bool Success, Dictionary<string, string>? Errors, User? User)> RegisterUser(RegisterRequest request)
        {
            var errors = new Dictionary<string, string>();

            // Walidacja wejściowa
            if (string.IsNullOrWhiteSpace(request.Email))
                errors["email"] = "Email is required.";

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
                errors["password"] = "Password must be at least 6 characters long.";

            if (errors.Count > 0)
                return (false, errors, null);

            // Sprawdzenie, czy użytkownik już istnieje
            if (await _userRepository.UserExists(request.Email))
            {
                errors["email"] = "User with this email already exists.";
                return (false, errors, null);
            }

            // Tworzenie nowego użytkownika
            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                Role = "Parent",
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                SignupSource = request.SignupSource,
                Language = request.Language,
                Country = request.Country,
                DeviceType = request.DeviceType,
                Os = request.Os,
                AppVersion = request.AppVersion,
                CreatedDate = DateTime.UtcNow
            };

            var createdUser = await _userRepository.CreateUser(user);
            return (true, null, createdUser);
        }

        public async Task<(bool Success, Dictionary<string, string>? Errors)> ResetPassword(string email, string newPassword)
        {
            var errors = new Dictionary<string, string>();

            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                errors["email"] = "No account found with this email.";
                return (false, errors);
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.UpdateUser(user);

            return (true, null);
        }

    }
}
