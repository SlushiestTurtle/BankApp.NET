using BankApp.Data;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Pages
{
    public class ViewAccount : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ViewAccount(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BankAccount> BankAccount { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BankAccount != null)
            {
                BankAccount = await _context.BankAccount.ToListAsync();
            }
        }
    }
}