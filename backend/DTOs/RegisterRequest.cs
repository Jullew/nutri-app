namespace NutriApp.DTOs
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string? Username { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Parent";
        public string? SignupSource { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? DeviceType { get; set; }
        public string? Os { get; set; }
        public string? AppVersion { get; set; }
    }
}
