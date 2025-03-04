using System;
using System.ComponentModel.DataAnnotations;
using NutriApp.Models.Users;

namespace NutriApp.Models.Subscriptions
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public decimal Amount { get; set; } // Kwota płatności

        [Required]
        public string PaymentMethod { get; set; } // np. "Credit Card", "PayPal"

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
    }
}
