using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Nutrition;
using NutriApp.Models.Users;

namespace NutriApp.Models.Children
{
    public class Child
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public List<Allergen> Allergies { get; set; } = new List<Allergen>();
        public List<Diet> Diets { get; set; } = new List<Diet>();
        public List<Intolerance> Intolerances { get; set; } = new List<Intolerance>();

        public List<TriedFood> TriedFoods { get; set; } = new List<TriedFood>();
    }
}
