using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Models;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.ProductManagements
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public CreateModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["CatId"] = new SelectList(this.categoryRepository.GetCategories().ToList(), "CatId", "CatId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            this.productRepository.AddProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}
