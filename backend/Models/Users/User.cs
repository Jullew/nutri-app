using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.AI;
using NutriApp.Models.Children;
using NutriApp.Models.Consultations;
using NutriApp.Models.Statistics;
using NutriApp.Models.Subscriptions;
using NutriApp.Models.Logs;
using NutriApp.Models.Feedbacks;

namespace NutriApp.Models.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = default!; // Zapewnia wartość domyślną

        public string? Username { get; set; }

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        public UserRole Role { get; set; } // "admin", "parent", "nutritionist", "allergist"

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

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>(); // Upewnia się, że Feedback to model

        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<AIRecommendation> AIRecommendations { get; set; } = new List<AIRecommendation>();
        public ICollection<AppUsageStats> AppUsageStats { get; set; } = new List<AppUsageStats>();
    }
}
