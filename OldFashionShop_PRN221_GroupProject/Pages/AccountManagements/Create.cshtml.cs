using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.AccountManagements
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        public CreateModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            this.accountRepository.AddAccount(Account);

            return RedirectToPage("./Index");
        }
    }
}
