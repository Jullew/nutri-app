using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Users;

namespace NutriApp.Models.Statistics
{
    public class AppUsageStats
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        public int TotalMealsLogged { get; set; }
        public int TotalConsultationsBooked { get; set; }
        public int TotalFeedbackGiven { get; set; }
        public DateTime LastActivity { get; set; } = DateTime.UtcNow;
    }
}
