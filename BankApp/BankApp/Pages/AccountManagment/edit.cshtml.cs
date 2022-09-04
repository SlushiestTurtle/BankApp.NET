using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApp.Data;
using BankApp.Models;

namespace BankApp.Pages.AccountManagment
{
    public class editModel : PageModel
    {
        private readonly BankApp.Data.ApplicationDbContext _context;

        public editModel(BankApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BankAccount BankAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BankAccount == null)
            {
                return NotFound();
            }

            var bankaccount =  await _context.BankAccount.FirstOrDefaultAsync(m => m.Id == id);
            if (bankaccount == null)
            {
                return NotFound();
            }
            BankAccount = bankaccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(BankAccount.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BankAccountExists(int id)
        {
          return (_context.BankAccount?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
