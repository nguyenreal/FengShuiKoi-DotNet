using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(string categoryId);
        bool SaveCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(string categoryId);
    }
}
