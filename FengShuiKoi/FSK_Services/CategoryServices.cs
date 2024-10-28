using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepo iCategoryRepo;
        public CategoryServices()
        {
            iCategoryRepo = new CategoryRepo();
        }
        public bool SaveCategory(Category category)
        {
            return iCategoryRepo.SaveCategory(category);
        }

        public bool DeleteCategory(string categoryId)
        {
            return iCategoryRepo.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return iCategoryRepo.GetCategories();
        }

        public Category GetCategoryById(string categoryId)
        {
            return iCategoryRepo.GetCategory(categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            return iCategoryRepo.UpdateCategory(category);
        }
    }
}
