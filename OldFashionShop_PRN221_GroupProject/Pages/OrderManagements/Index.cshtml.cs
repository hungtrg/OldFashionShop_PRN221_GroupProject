using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace OldFashionShop_PRN221_GroupProject.Pages.OrderManagements
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Models.MyStoreManagementContext _context;

        public IndexModel(DataLayer.Models.MyStoreManagementContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync(string quantity, int id)
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Account).ToListAsync();

            }
        }
    }
}
