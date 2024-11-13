using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
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

        public static void CreateBlog(Blog blog)
        {
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Blogs.Add(blog);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBlog(Blog b)
        {
            try
            {
                using var context = new FengShuiKoiDbContext();
                var p1 =
                    context.Blogs.SingleOrDefault(c => c.BlogId == b.BlogId);
                context.Blogs.Remove(p1);

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static void UpdateBlog(Blog blog)
        {
            try
            {
                using var context = new FengShuiKoiDbContext();
                context.Entry<Blog>(blog).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Blog GetBlogByTitle(string title)
        {
            using var db = new FengShuiKoiDbContext();
            return db.Blogs.FirstOrDefault(c => c.Title.Equals(title));
        }

        public static Blog GetBlogById(string id)
        {
            using var db = new FengShuiKoiDbContext();
            return db.Blogs.FirstOrDefault(c => c.BlogId.Equals(id));
        }
    }
    
}
