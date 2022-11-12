using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace OldFashionShop_PRN221_GroupProject.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly DataLayer.Models.MyStoreManagementContext _context;

        public HomePageModel(DataLayer.Models.MyStoreManagementContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Cat).ToListAsync();
        }
    }
}
