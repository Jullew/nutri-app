using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Nutrition;

namespace NutriApp.Models.Recipes
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        public string Instructions { get; set; } = default!;

        public List<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
        public List<Allergen> Allergens => GetAllergens();


        // Automatyczne przeliczanie wartości odżywczych
        public double TotalCalories => CalculateCalories();
        public double TotalFat => CalculateFat();
        public double TotalCarbohydrates => CalculateCarbohydrates();
        public double TotalProteins => CalculateProteins();
        public double TotalFiber => CalculateFiber();
        public double TotalIron => CalculateIron();

        private double CalculateCalories() => Ingredients.Sum(i => i.FoodItem.NutritionInfo.Calories * (i.Quantity / 100));

        private double CalculateFat() => Ingredients.Sum(i => i.FoodItem.NutritionInfo.Fats * (i.Quantity / 100));
        private double CalculateCarbohydrates() => Ingredients.Sum(i => i.FoodItem.NutritionInfo.Carbs * (i.Quantity / 100));
        private double CalculateProteins() => Ingredients.Sum(i => i.FoodItem.NutritionInfo.Proteins * (i.Quantity / 100));
        private double CalculateFiber() => Ingredients.Sum(i => i.FoodItem.NutritionInfo.Fiber * (i.Quantity / 100));
        private double CalculateIron() => Ingredients.Sum(i => i.FoodItem.NutritionInfo.Iron * (i.Quantity / 100));

        private List<Allergen> GetAllergens() => Ingredients
          .SelectMany(i => i.FoodItem.Allergens)
          .Distinct()
          .ToList();
    }
}
