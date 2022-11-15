using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.OrderManagements
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository orderRepository;

        public DetailsModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [BindProperty]
        public string quantity { get; set; }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var order = this.orderRepository.GetOrderById(id);
            Order = order;

            return Page();
        }

    }
}
