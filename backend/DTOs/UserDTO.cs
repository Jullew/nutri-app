using System;
using System.Collections.Generic;
using NutriApp.DTOs.Children;

namespace NutriApp.DTOs.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string? Username { get; set; }
        public string Role { get; set; } = default!;
        public string? PremiumLevel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? DeviceType { get; set; }
        public string? Os { get; set; }
        public string? AppVersion { get; set; }

        // Lista dzieci użytkownika
        public List<ChildDTO>? Children { get; set; }
    }
}
