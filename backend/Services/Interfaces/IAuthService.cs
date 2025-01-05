using NutriApp.DTOs.Requests;
using NutriApp.Responses;

namespace NutriApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse> RegisterUser(RegisterRequest request);
        Task<(bool Success, Dictionary<string, string>? Errors, string? Token)> Login(LoginRequest request);
    }
}
