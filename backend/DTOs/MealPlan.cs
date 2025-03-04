namespace NutriApp.DTOs.Meals
{
    public class MealPlanDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<Guid> RecipeIds { get; set; }
    }
}