using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace BankApp.Models
{
    public class Person : IdentityUser
    {
        [AllowNull]
        public string FirstName { get; set; }
        [AllowNull]
        public string LastName { get; set; }
    }
}
