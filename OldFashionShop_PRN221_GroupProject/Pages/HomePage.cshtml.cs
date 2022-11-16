using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public HomePageModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IList<Product> Product { get; set; } = default;
        public IList<Product> ProductMen { get; set; } = default;
        public IList<Product> ProductWomen { get; set; } = default;
        public IList<Product> ProductKid { get; set; } = default;
        public IList<Product> ProductAccessory { get; set; } = default;

        public async Task OnGetAsync()
        {
            Product = this.productRepository.GetProducts().ToList();
            ProductWomen = Product.Where(x => x.CatId == 1).ToList();
            ProductMen = Product.Where(x => x.CatId == 2).ToList();
            ProductKid = Product.Where(x => x.CatId == 3).ToList();
            ProductAccessory = Product.Where(x => x.CatId == 4).ToList();
        }
    }
}
