using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankApp.Data;
using BankApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Pages.AccountManagment
{
    public class CreateAccountModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateAccountModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string? Email { get; set; }

        public IdentityUser? Person { get; set; }

        public async Task<IActionResult> OnPostAsynce()
        {
            Person = await _userManager.FindByEmailAsync(Email);

            return Page();
        }

        [BindProperty]
        public BankAccount BankAccount { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            BankAccount.Person = Person;         

            if (!ModelState.IsValid || _context.BankAccount == null || BankAccount == null)
            {
                return Page();
            }

            _context.BankAccount.Add(BankAccount);
          await _context.SaveChangesAsync();

          return RedirectToPage("./ViewAccount");
        }
    }
}
