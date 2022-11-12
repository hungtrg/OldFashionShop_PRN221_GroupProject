using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Models;

namespace OldFashionShop_PRN221_GroupProject.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly DataLayer.Models.MyStoreManagementContext _context;

        public CreateModel(DataLayer.Models.MyStoreManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
