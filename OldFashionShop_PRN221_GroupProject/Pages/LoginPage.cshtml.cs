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
            var account = this.accountRepository.GetAccount(Email);
            if (account == null)
            {
                ViewData["ErrorMessage"] = "Wrong input format!";
                return NotFound();
            }
            if (account != null)
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
                if (checkRole != "Manager" || checkRole == null)
                {
                    ViewData["ErrorMessage"] = "You are not allow to use this function!";
                    return Page();
                }
                else
                {
                    return RedirectToPage("./Privacy");
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "You are not allow to use this function!";
                return Page();
            }
        }
    }
}
