using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Nutrition;

namespace NutriApp.Models.Children
{
    public class Allergy
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChildId { get; set; }

        [Required]
        public Guid AllergenId { get; set; }

        public Child Child { get; set; }
        public Allergen Allergen { get; set; }
    }
}
