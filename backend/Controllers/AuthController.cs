using Microsoft.AspNetCore.Mvc;
using NutriApp.DTOs;
using NutriApp.Responses;
using NutriApp.Services;


namespace NutriApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authService.RegisterUser(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (success, errors, token) = await _authService.Login(request);

            if (!success)
            {
                return BadRequest(ApiResponse.ErrorResponse("Login failed.", errors));
            }

            return Ok(ApiResponse.SuccessResponse("Login successful.", new { Token = token }));
        }


    }
}
