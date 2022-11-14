using BusinessLayer.Repository;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OldFashionShop_PRN221_GroupProject.Pages.Profile
{
    public class MyProfileModel : PageModel
    {
        private readonly IAccountRepository accoutRepository;

        public MyProfileModel(IAccountRepository accoutRepository)
        {
            this.accoutRepository = accoutRepository;
        }

        [BindProperty]
        public Account Account { get; set; }

        public IActionResult OnGet(string email)
        {
            if (HttpContext.Session.GetString("ROLE") == null)
            {
                ViewData["ErrorMessage"] = "Login to access this function!";
                return RedirectToPage("./LoginPage");
            }
            if (email == null)
            {
                return NotFound();
            }
            var account = accoutRepository.GetAccount(email);
            Account = account;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Account.Phone.Length != 10)
            {
                ViewData["ErrorMessage"] = "Phone length must be 10";
                return Page();
            }
            if (Account.FullName == null)
            {
                ViewData["ErrorMessage"] = "Full name length must be > 12 ";
                return Page();
            }
            this.accoutRepository.UpdateAccount(Account);
            HttpContext.Session.SetString("FULLNAME", Account.FullName);
            ViewData["ErrorMessage"] = "Update successed!";

            return Page();
        }
    }
}
