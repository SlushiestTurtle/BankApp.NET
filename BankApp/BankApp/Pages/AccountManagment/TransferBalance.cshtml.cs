using BankApp.Data;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
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

        [BindProperty]
        public List<SelectListItem>? selectListItems { get; set; }
        public string? SelectedItem { get; set; }
        public float SelectedBalance { get; set; }

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

            List<BankAccount> listOfAccount = await _context.BankAccount.ToListAsync();
            List<BankAccount> userListAccount = new List<BankAccount>();
            foreach(var account in listOfAccount)
            {
                if(bankaccount.Person == account.Person)
                {
                    userListAccount.Add(account);
                }
            }

            selectListItems = userListAccount.Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();

            return Page();
        }

        public async void OnPost()
        {
            if(SelectedItem != null)
            {
                NotFound();
            }
            if(SelectedBalance != 0)
            {
                Page();
            }

            BankAccount? selectedAccount = await _context.BankAccount.FirstOrDefaultAsync(m => m.Id == Int32.Parse(SelectedItem));

            if (selectedAccount == null)
            {
                NotFound();
            }

            selectedAccount.Balance += SelectedBalance;
            BankAccount.Balance -= SelectedBalance;

            _context.BankAccount.Update(selectedAccount);
            _context.BankAccount.Update(BankAccount);
            await _context.SaveChangesAsync();

            Redirect("./ViewAccount");
        }
    }
}
