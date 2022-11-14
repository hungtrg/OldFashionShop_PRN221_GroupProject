using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLayer.Models;
using OldFashionShop_PRN221_GroupProject.Pages.Helpers;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Repository;

namespace OldFashionShop_PRN221_GroupProject.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IConfiguration Configuration;

        public IndexModel(IConfiguration configuration, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            Configuration = configuration;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public PaginatedList<Product> Product { get; set; }
        public IList<Category> Categories { get; set; }
        public string search { get; set; }
        public string filter { get; set; }

        public async Task OnGetAsync(string search, string? filter, int? pageIndex)
        {
            if (search != null)
            {
                pageIndex = 1;
            }
            else
            {
                search = filter;
            }
            Categories = this.categoryRepository.GetCategories().ToList();
            var productsIQ = this.productRepository.GetProducts().ToList();

            if (!string.IsNullOrEmpty(search))
            {
                productsIQ = this.productRepository.SearchProducts(search).ToList();
            }
            var pageSize = Configuration.GetValue("PageSize", 10);
            Product = await PaginatedList<Product>.CreateAsync(productsIQ, pageIndex ?? 1, pageSize);
        }
    }
}
