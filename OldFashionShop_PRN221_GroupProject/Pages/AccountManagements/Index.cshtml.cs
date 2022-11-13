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
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        public string search { get; set; }

        public IndexModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IList<Account> Account { get; set; } = default;

        public async Task OnGetAsync(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                Account = this.accountRepository.SearchAccounts(search).ToList();
            }
            else
            {
                Account = this.accountRepository.GetAccounts().ToList();
            }
        }
    }
}
