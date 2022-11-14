using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                products = myStoreDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public IEnumerable<Product> SearchProducts(string search)
        {
            List<Product> products;
            try
            {
                var productDB = new MyStoreManagementContext();
                products = productDB.Products.Where(products => products.ProductName.Contains(search) || products.Title.Contains(search) || products.CatId.ToString().Contains(search) || products.Discount.ToString().Contains(search) || products.Price.ToString().Contains(search)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductByID(int productID)
        {
            Product product = null;
            try
            {
                var myStoreDB = new MyStoreManagementContext();
                product = myStoreDB.Products.SingleOrDefault(product => product.ProductId == productID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddProduct(Product product)
        {
            try
            {
                Product p = GetProductByID(product.ProductId);
                if (p == null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Products.Add(p);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product has already existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = GetProductByID(product.ProductId);
                if (p != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveProduct(Product product)
        {
            try
            {
                Product p = GetProductByID(product.ProductId);
                if (p != null)
                {
                    var myStoreDB = new MyStoreManagementContext();
                    myStoreDB.Remove(p);
                    myStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product has not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
