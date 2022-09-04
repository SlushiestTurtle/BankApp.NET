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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateAccountModel(ApplicationDbContext context, IHttpContextAccessor contextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page(); 
        }

        [BindProperty]
        public BankAccount BankAccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BankAccount == null || BankAccount == null)
            {
                return Page();
            }

            string findUserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _userManager.FindByIdAsync(findUserId);

            if (user == null)
            {
                return NotFound();
            }
            BankAccount.Person.Equals(user);

            _context.BankAccount.Add(BankAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ViewAccount");
        }
    }
}
