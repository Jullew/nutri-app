using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Children
{
    public class Diet
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } // np. "Wegetariańska", "Bezglutenowa"
    }
}
