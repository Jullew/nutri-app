using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Recipes;

namespace NutriApp.Models.Meals
{
    public enum MealType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack
    }

    public class MealPlan
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int AgeInMonths { get; set; } // Wiek dziecka w miesiącach

        [Required]
        public MealType Type { get; set; } // Śniadanie, Obiad, itd.

        [Required]
        public Guid RecipeId { get; set; } // Przepis dla posiłku

        public Recipe Recipe { get; set; } = default!;
    }
}
