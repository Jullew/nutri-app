using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string? Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // "admin", "parent", "nutritionist"

        public string? PremiumLevel { get; set; } // "Basic", "Gold" itd.

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }

        public string? SignupSource { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? DeviceType { get; set; }
        public string? Os { get; set; }
        public string? AppVersion { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();
        public ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();
    }
}
