using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Nutrition;

namespace NutriApp.Models.Recipes
{
    public class RecipeIngredient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecipeId { get; set; }

        [Required]
        public Guid FoodItemId { get; set; }

        [Required]
        public float Quantity { get; set; } // Ilość

        [Required]
        public MeasurementUnit Unit { get; set; } // Jednostka miary

        public Recipe Recipe { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}
