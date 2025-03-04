using System;
using System.ComponentModel.DataAnnotations;

namespace NutriApp.Models.Users
{
    public class PasswordResetToken
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime Expiration { get; set; } // Token ważny np. 30 minut

        public User User { get; set; }
    }
}
