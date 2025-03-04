using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Nutrition
{
    public class Allergen
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } // np. "Orzechy", "Mleko", "Gluten"
    }
}
