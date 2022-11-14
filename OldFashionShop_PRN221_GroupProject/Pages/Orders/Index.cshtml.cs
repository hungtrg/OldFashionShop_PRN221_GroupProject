using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository orderRepository;

        public IndexModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
            }
        }
    }
}
