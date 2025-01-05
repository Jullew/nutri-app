using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NutriApp.DTOs.Requests;
using NutriApp.Responses;
using NutriApp.Services.Interfaces;


namespace NutriApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<RegisterRequest> _registerValidator;
        private readonly IValidator<LoginRequest> _loginValidator;


        public AuthController(IAuthService authService, IValidator<RegisterRequest> registerValidator, IValidator<LoginRequest> loginValidator)
        {
            _authService = authService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            ValidationResult validationResult = await _registerValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage);
                return BadRequest(ApiResponse.ErrorResponse("Validation failed.", errors));
            }
            var response = await _authService.RegisterUser(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            ValidationResult validationResult = await _loginValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage);
                return BadRequest(ApiResponse.ErrorResponse("Validation failed.", errors));
            }

            var (success, errorsDict, token) = await _authService.Login(request);

            if (!success)
            {
                return BadRequest(ApiResponse.ErrorResponse("Login failed.", errorsDict));
            }

            return Ok(ApiResponse.SuccessResponse("Login successful.", new { Token = token }));
        }


    }
}
