using BusinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace OldFashionShop_PRN221_GroupProject.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        [BindProperty]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public LoginPageModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult OnPost()
        {
            var account = this.accountRepository.CheckLogin(Email, Password);
            if (account != null)
            {
                if (account.Active == true)
                {
                    var checkRole = "";
                    switch (account.RoleId)
                    {
                        case 0:
                            checkRole = "Admin";
                            break;
                        case 1:
                            checkRole = "Manager";
                            break;
                        case 2:
                            checkRole = "Staff";
                            break;
                    }
                    HttpContext.Session.SetString("ROLE", checkRole);
                    HttpContext.Session.SetString("EMAIL", account.Email);
                    HttpContext.Session.SetString("FULLNAME", account.FullName);
                    HttpContext.Session.SetString("ACCOUNT_ID", $"{account.AccountId}");
                    return RedirectToPage("./HomePage");
                }
                else
                {
                    ViewData["ErrorMessage"] = "Account Blocked, contact with Admin.";
                    return Page();
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Wrong email or password!";
                return Page();
            }
        }
    }
}
