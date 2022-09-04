using BankApp.Data;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Pages.AccountManagment
{
    public class TransferBalanceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TransferBalanceModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public BankAccount BankAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BankAccount == null)
            {
                return NotFound();
            }

            var bankaccount = await _context.BankAccount.FirstOrDefaultAsync(m => m.Id == id);
            if (bankaccount == null)
            {
                return NotFound();
            }
            else
            {
                BankAccount = bankaccount;
            }
            return Page();
        }
    }
}
