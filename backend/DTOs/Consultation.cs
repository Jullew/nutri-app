namespace NutriApp.DTOs.Consultations
{
    public class ConsultationDto
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Guid SpecialistId { get; set; }
        public string Status { get; set; }
    }
}