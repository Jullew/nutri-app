using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Recipes;
using NutriApp.Models.Users;

namespace NutriApp.Models.Feedbacks
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; } // Użytkownik, który dodał opinię

        public Guid? SpecialistId { get; set; } // Jeśli dotyczy dietetyka/alergologa
        public Guid? RecipeId { get; set; } // Jeśli dotyczy przepisu

        [Required]
        public FeedbackType Type { get; set; } // Określa, czego dotyczy feedback

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; } // Ocena 1-5 gwiazdek

        public string? Comment { get; set; } // Opinie tekstowe

        [Required]
        public FeedbackStatus Status { get; set; } = FeedbackStatus.Pending; // Domyślnie oczekuje na akceptację

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; } // Data zatwierdzenia

        public User User { get; set; }
        public User? Specialist { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
