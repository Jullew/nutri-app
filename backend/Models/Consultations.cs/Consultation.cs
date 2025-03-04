using System;
using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Consultations
{
    public class Consultation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ParentId { get; set; }

        [Required]
        public Guid SpecialistId { get; set; } // Może być dietetyk lub alergolog

        [Required]
        public SpecialistType SpecialistType { get; set; } // Dodajemy nowy enum

        [Required]
        public DateTime ConsultationDate { get; set; }

        [Required]
        public ConsultationStatus Status { get; set; } = ConsultationStatus.Pending; // Domyślnie oczekuje

        public string? Notes { get; set; } // Notatki specjalisty

        public User Parent { get; set; }
        public User Specialist { get; set; }
    }
}
