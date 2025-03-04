using System;
using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Nutrition
{
    public class NutritionInfo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FoodItemId { get; set; }

        public float Calories { get; set; } // kcal na 100 g/ml
        public float Proteins { get; set; } // Białko (g)
        public float Carbs { get; set; } // Węglowodany (g)
        public float Fats { get; set; } // Tłuszcze (g)
        public float Fiber { get; set; } // Błonnik (g)
        public float Iron { get; set; } // Żelazo (mg)

        public FoodItem FoodItem { get; set; }
    }
}
