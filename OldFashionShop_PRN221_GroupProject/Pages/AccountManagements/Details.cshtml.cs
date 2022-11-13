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
    public class DetailsModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        public DetailsModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [BindProperty]
        public string quantity { get; set; }

        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            var account = this.accountRepository.GetAccount(email);
            Account = account;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (quantity != null) { }
            return Page();
        }
    }
}
