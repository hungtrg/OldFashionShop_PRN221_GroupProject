using BusinessLayer.Repository;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OldFashionShop_PRN221_GroupProject.Pages.Products
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
