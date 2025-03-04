using System;
using System.Collections.Generic;

namespace NutriApp.DTOs.Children
{
    public class ChildDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public Guid UserId { get; set; }

        // Lista alergii dziecka
        public List<string>? Allergies { get; set; }

        // Lista nietolerancji dziecka
        public List<string>? Intolerances { get; set; }

        // Lista diet dziecka
        public List<string>? Diets { get; set; }

        // Lista próbowanych produktów
        public List<string>? TriedFoods { get; set; }
    }
}
