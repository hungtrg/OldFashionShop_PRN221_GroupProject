﻿using System;
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
        private readonly IOrderDetailRepository orderDetailRepository;

        public DetailsModel(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public IList<OrderDetail> OrderDetail { get; set; } = default!;


        public async Task OnGetAsync(int? id)
        {
            if (this.orderDetailRepository.GetOrderDetails() != null)
            {
                OrderDetail = this.orderDetailRepository.GetOrderDetails().Where(od => od.OrderId == id).ToList();
            }
        }
    }
}
