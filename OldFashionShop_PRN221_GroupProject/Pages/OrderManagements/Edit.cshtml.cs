using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.OrderManagements
{
    public class EditModel : PageModel
    {
        private readonly IOrderRepository orderRepository;

        public EditModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = this.orderRepository.GetOrderById((int)id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (OrderExists(Order.OrderId))
            {
                this.orderRepository.UpdateOrder(Order);
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return this.orderRepository.GetOrders().Any(o => o.OrderId == id);
        }
    }
}
