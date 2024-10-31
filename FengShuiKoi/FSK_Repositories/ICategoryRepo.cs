using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public interface ICategoryRepo
    {
        List<Category> GetCategories();
        Category GetCategory(string id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(string categoryId);
    }
}
