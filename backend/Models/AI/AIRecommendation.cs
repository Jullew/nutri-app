using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Users;

namespace NutriApp.Models.AI
{
    public class AIRecommendation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; } = default!;

        [Required]
        public string RecommendationText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
