using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class BlogDAO
    {
        public static List<Blog> GetBlogs()
        {
            var listBlogs = new List<Blog>();
            try
            {
                using var context = new FengShuiKoiDbContext();
                listBlogs = context.Blogs.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBlogs;
        }

        public static void saveBlog(Blog b)
        {
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Blogs.Add(b);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void deleteBlog(Blog b)
        {
            using var context = new FengShuiKoiDbContext();

        }
    }
    
}
