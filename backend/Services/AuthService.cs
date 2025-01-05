using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NutriApp.Models;
using NutriApp.Repositories.Interfaces;
using NutriApp.Responses;
using NutriApp.Services.Interfaces;
using NutriApp.DTOs.Requests;

namespace NutriApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _jwtSecret;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new ArgumentNullException("JWT_SECRET is not set");
        }

        public async Task<ApiResponse> RegisterUser(RegisterRequest request)
        {
            if (await _userRepository.UserExists(request.Email))
            {
                return ApiResponse.ErrorResponse("Validation failed.", new Dictionary<string, string> { { "email", "User with this email already exists." } });
            }

            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                Role = request.Role,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                SignupSource = request.SignupSource,
                Language = request.Language,
                Country = request.Country,
                DeviceType = request.DeviceType,
                Os = request.Os,
                AppVersion = request.AppVersion
            };

            await _userRepository.CreateUser(user);
            return ApiResponse.SuccessResponse("User registered successfully.");
        }

        public async Task<(bool Success, Dictionary<string, string>? Errors, string? Token)> Login(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return (false, new Dictionary<string, string> { { "email", "Invalid credentials." } }, null);
            }

            var token = GenerateJwtToken(user);
            return (true, null, token);
        }

        private string GenerateJwtToken(User user)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_jwtSecret);
            var key = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", user.Role)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
