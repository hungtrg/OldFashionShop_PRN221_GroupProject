using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Models;
using BusinessLayer.Repository;
using System.ComponentModel.DataAnnotations;

namespace OldFashionShop_PRN221_GroupProject.Pages
{
    public class RegisterPageModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        public RegisterPageModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [BindProperty]
        public Account Account { get; set; }

        [BindProperty]
        [StringLength(maximumLength: 20, 
            ErrorMessage = "Password's length at least 6 character!", 
            MinimumLength = 6)]
        [Required(ErrorMessage = "Confirm Password is required!")]
        public string Password { get; set; }

        [BindProperty]
        [StringLength(maximumLength: 20,
            ErrorMessage = "Password's length at least 6 character!",
            MinimumLength = 6)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Account account = new Account
                {
                    AccountId = Account.AccountId,
                    FullName = Account.FullName,
                    Email = Account.Email,
                    Password = Password,
                    Phone = Account.Phone,
                    RoleId = 3,
                    Active = true

                };
                accountRepository.AddAccount(account);
                return RedirectToPage("/HomePage");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }
    }
}
