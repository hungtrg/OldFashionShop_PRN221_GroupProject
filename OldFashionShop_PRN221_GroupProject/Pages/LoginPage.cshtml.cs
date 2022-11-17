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
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The lenght of Password is from 6 to 20 charaters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public LoginPageModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var account = this.accountRepository.CheckLogin(Email, Password);
            if (account != null)
            {
                if (account.Active == true)
                {
                    var checkRole = "";
                    switch (account.RoleId)
                    {
                        case 1:
                            checkRole = "Admin";
                            break;
                        case 2:
                            checkRole = "Manager";
                            break;
                        case 3:
                            checkRole = "Staff";
                            break;
                        case 4:
                            checkRole = "Customer";
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
