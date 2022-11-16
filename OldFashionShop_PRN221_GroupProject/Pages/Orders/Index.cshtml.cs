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

        public string search { get; set; }
        public int? id { get; set; }

        public IndexModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IList<Order> Order { get; set; } = default;

        public Order updateOrder { get; set; } = default;


        public async Task OnGetAsync(string search, int? id)
        {
            int accountId = int.Parse(HttpContext.Session.GetString("ACCOUNT_ID"));
            if (!string.IsNullOrEmpty(search))
            {
                Order = this.orderRepository.SearchOrders(search).Where(o => o.AccountId == accountId).ToList();
            }
            else
            {
                Order = this.orderRepository.GetOrders().Where(o => o.AccountId == accountId).ToList();
            }
            
        }

        public IActionResult OnPost(int? id)
        {
            updateOrder = this.orderRepository.GetOrderById((int)id);

            var order = new Order
            {
                OrderId = updateOrder.OrderId,
                AccountId = updateOrder.AccountId,
                OrderDate = updateOrder.OrderDate,
                Deleted = true,
                Note = updateOrder.Note,
                Status = 0
            };
            this.orderRepository.UpdateOrder(order);

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostComplete(int? id)
        {
            updateOrder = this.orderRepository.GetOrderById((int)id);

            var order = new Order
            {
                OrderId = updateOrder.OrderId,
                AccountId = updateOrder.AccountId,
                OrderDate = updateOrder.OrderDate,
                Deleted = true,
                Note = updateOrder.Note,
                Status = 3
            };
            this.orderRepository.UpdateOrder(order);

            return RedirectToPage("./Index");
        }
    }
}
