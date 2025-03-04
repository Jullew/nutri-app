using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Children
{
    public class Intolerance
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } // np. "Laktoza", "Fruktoza", "Gluten"
    }
}
