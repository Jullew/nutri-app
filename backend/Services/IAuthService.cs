using NutriApp.DTOs;
using NutriApp.Responses;

namespace NutriApp.Services
{
    public interface IAuthService
    {
        Task<ApiResponse> RegisterUser(RegisterRequest request);
        Task<(bool Success, Dictionary<string, string>? Errors, string? Token)> Login(LoginRequest request);
    }
}
