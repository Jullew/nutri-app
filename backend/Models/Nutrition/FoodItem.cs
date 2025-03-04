using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Nutrition
{
    public class FoodItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } // np. "Jabłko", "Jogurt naturalny"

        [Required]
        public int RecommendedAgeInMonths { get; set; } // Wiek od którego można spożywać

        [Required]
        public FoodType Type { get; set; } = FoodType.Raw; // Raw, Processed, RecipeBase

        [Required]
        public MeasurementUnit DefaultUnit { get; set; } // np. Gram, Milliliter, Piece

        public bool ContainsAllergen { get; set; }
        public bool HighInIron { get; set; }

        public List<Allergen> Allergens { get; set; } = new List<Allergen>();

        public NutritionInfo NutritionInfo { get; set; }
    }
}
