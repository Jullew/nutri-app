using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Children;
using NutriApp.Models.Nutrition;

namespace NutriApp.Models.Logs
{
    public class MealLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChildId { get; set; }

        [Required]
        public Guid FoodItemId { get; set; }

        [Required]
        public DateTime ConsumedAt { get; set; } = DateTime.UtcNow;

        public Child Child { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}
