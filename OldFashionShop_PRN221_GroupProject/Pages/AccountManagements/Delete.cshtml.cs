using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.AccountManagements
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        public DeleteModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return NotFound();
            }

            var account = this.accountRepository.GetAccount(email);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string email)
        {
            if (email == null)
            {
                return NotFound();
            }
            var account = this.accountRepository.GetAccount(email);

            if (account != null)
            {
                Account = account;
                this.accountRepository.RemoveAccount(account);
            }

            return RedirectToPage("./Index");
        }
    }
}
