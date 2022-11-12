using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(Category category);
    }

    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category category) => CategoryDAO.Instance.AddCategory(category);

        public IEnumerable<Category> GetCategories() => CategoryDAO.Instance.GetCategoryList();

        public Category GetCategoryById(int id) => CategoryDAO.Instance.GetCategoryByID(id);

        public void RemoveCategory(Category category) => CategoryDAO.Instance.RemoveCategory(category);

        public void UpdateCategory(Category category) => CategoryDAO.Instance.UpdateCategory(category);
    }
}
