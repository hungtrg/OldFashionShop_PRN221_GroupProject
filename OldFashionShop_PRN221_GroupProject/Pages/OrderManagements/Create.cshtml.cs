using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Models;

namespace OldFashionShop_PRN221_GroupProject.Pages.OrderManagements
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
        ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
