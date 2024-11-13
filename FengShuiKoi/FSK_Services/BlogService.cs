using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepo blogRepo;
        public BlogService()
        {
            blogRepo = new BlogRepo();
        }
        public void CreateBlog(Blog blog)
        {
            blogRepo.CreateBlog(blog);
        }

        public void DeleteBlog(Blog b)
        {
            blogRepo.DeleteBlog(b);
        }

        public Blog GetBlogById(string id)
        {
            return blogRepo.GetBlogById(id);
        }

        public Blog GetBlogByTitle(string title)
        {
            return blogRepo.GetBlogByTitle(title);
        }

        public List<Blog> GetBlogs()
        {
            return blogRepo.GetBlogs();
        }

        public void UpdateBlog(Blog blog)
        {
            blogRepo.UpdateBlog(blog);
        }
    }
}
