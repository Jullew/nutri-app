using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace NutriApp.DTOs.Requests
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters long.")]
        public string? Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "Parent";
        public string? SignupSource { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? DeviceType { get; set; }
        public string? Os { get; set; }
        public string? AppVersion { get; set; }
    }

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(6).WithMessage("Username must be at least 6 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(x => x.Role)
                .Must(x => x == "Parent" || x == "Admin" || x == "Nutritionist")
                .WithMessage("Invalid role type.");

            RuleFor(x => x.Language)
                .Matches("^[a-z]{2}$").When(x => !string.IsNullOrEmpty(x.Language))
                .WithMessage("Language must be a two-letter ISO code.");

            RuleFor(x => x.Country)
                .Matches("^[A-Z]{2}$").When(x => !string.IsNullOrEmpty(x.Country))
                .WithMessage("Country must be a two-letter ISO country code.");
        }
    }
}
