namespace NutriApp.DTOs.Feedback
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}