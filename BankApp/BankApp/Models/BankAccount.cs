using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankApp.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required, NotNull]
        public float Balance { get; set; }
        public IdentityUser? Person { get; set; }
    }
}
