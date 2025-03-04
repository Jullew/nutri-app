using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Users;

namespace NutriApp.Models.Subscriptions
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }

        [Required]
        public string Plan { get; set; } // np. "Basic", "Premium", "Gold"

        public bool IsActive => EndDate == null || EndDate > DateTime.UtcNow;

        public User User { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
