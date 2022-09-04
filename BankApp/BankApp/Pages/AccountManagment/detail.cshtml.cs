using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankApp.Data;
using BankApp.Models;

namespace BankApp.Pages.AccountManagment
{
    public class detailModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public detailModel(ApplicationDbContext context)
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
