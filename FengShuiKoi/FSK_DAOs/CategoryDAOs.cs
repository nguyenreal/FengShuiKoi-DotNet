using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class CategoryDAOs
    {
        private FengShuiKoiDbContext dbContext;
        private static CategoryDAOs instance;

        public static CategoryDAOs Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAOs();
                return instance;
            }
        }

        public CategoryDAOs()
        {
            dbContext = new FengShuiKoiDbContext();
        }

        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        public bool AddCategory(Category category)
        {
            bool isSuccess = false;
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Categories.Add(category);
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool UpdateCategory(Category category)
        {
            bool isSuccess = false;
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Entry(category).State = 
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool DeleteCategory(String id)
        {
            bool isSuccess = false;
            try
            {
                using var context = new FengShuiKoiDbContext();
                var existingCategory = context.Categories
                    .SingleOrDefault(c => c.CategoryId == GetCategory(id).CategoryId);
                if (existingCategory == null)
                {
                    throw new Exception("Category does not exist!");
                }
                context.Categories.Remove(existingCategory);
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public Category GetCategory(string categoryId)
        {
            using var db = new FengShuiKoiDbContext();
            return db.Categories.FirstOrDefault(c => c.CategoryId.Equals(categoryId));
        }
    }
}
