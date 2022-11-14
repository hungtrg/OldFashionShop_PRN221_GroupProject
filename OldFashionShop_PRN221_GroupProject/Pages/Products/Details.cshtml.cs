using BusinessLayer.Repository;
using DataLayer.Models;
using DataLayer.RedirectModel;
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
        public int Quantity { get; set; } = 1;

        public int Id { get; set; }
        public Product Product { get; set; }
        public Item Item { get; set; }
        public void OnGet(int id)
        {
            var product = this.productRepository.GetProductById(id);
            Product = product;
            Id = id;
        }

        public async Task<IActionResult> OnPostAsync(int id, int quantity)
        {
            var product = this.productRepository.GetProductById(id);
            Id = id;
            Product = product;
            Quantity = quantity;
            var item = new Item();
            if (quantity != null)
            {
                item.product = product;
                item.quantity = Quantity;
            }
            Item = item;
            return Page();
        }
    }
}