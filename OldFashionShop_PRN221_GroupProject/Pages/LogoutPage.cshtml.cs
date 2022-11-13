using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OldFashionShop_PRN221_GroupProject.Pages
{
    public class LogoutPageModel : PageModel
    {
        public RedirectToPageResult OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/LoginPage");
        }
    }
}
