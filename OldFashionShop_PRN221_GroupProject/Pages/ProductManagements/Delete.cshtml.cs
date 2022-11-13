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
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = this.productRepository.GetProductById(id);

            if (product != null)
            {
                Product = product;
                this.productRepository.RemoveProduct(product);
            }

            return RedirectToPage("./Index");
        }
    }
}
