using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public Product GetProductById(int id) => ProductDAO.Instance.GetProductByID(id);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public void RemoveProduct(Product product) => ProductDAO.Instance.RemoveProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
