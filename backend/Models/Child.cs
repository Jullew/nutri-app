using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriApp.Models
{
    public class Child
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public User Parent { get; set; }
    }
}
