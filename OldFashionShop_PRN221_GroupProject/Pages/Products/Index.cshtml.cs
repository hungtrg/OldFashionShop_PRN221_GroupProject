using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public string search { get; set; }

        public IndexModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IList<Product> Product { get; set; } = default;

        public async Task OnGetAsync(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                Product = this.productRepository.SearchProducts(search).ToList();
            }
            else
            {
                Product = this.productRepository.GetProducts().ToList();
            }
        }
    }
}
