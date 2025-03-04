using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Children;

namespace NutriApp.Models.Nutrition
{
    public class TriedFood
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChildId { get; set; }

        [Required]
        public Guid FoodItemId { get; set; }

        public Child Child { get; set; }
        public FoodItem FoodItem { get; set; }

        [Required]
        public FoodReaction Reaction { get; set; } = FoodReaction.NoReaction; // Domyślnie brak reakcji

        public DateTime DateTried { get; set; } = DateTime.UtcNow;
    }
}
