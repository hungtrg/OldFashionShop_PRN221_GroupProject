using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OldFashionShop_PRN221_GroupProject.Pages.Products
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public string quantity { get; set; }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (quantity != null) { }
            return Page();
        }
    }
}
