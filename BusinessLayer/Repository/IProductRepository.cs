using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> SearchProducts(string search);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public Product GetProductById(int id) => ProductDAO.Instance.GetProductByID(id);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public void RemoveProduct(Product product) => ProductDAO.Instance.RemoveProduct(product);

        public IEnumerable<Product> SearchProducts(string search) => ProductDAO.Instance.SearchProducts(search);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
