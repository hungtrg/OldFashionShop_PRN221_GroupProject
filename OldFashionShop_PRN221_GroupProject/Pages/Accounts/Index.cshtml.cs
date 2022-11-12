using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace OldFashionShop_PRN221_GroupProject.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Models.MyStoreManagementContext _context;

        public IndexModel(DataLayer.Models.MyStoreManagementContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts
                .Include(a => a.Role).ToListAsync();
        }
    }
}
