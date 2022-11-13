using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.ProductManagements
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public DetailsModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [BindProperty]
        public string quantity { get; set; }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = this.productRepository.GetProductById(id);
            Product = product;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (quantity != null) { }
            return Page();
        }
    }
}
