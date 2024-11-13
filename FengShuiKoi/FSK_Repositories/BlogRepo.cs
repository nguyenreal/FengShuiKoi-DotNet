using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class BlogRepo : IBlogRepo
    {
        public void CreateBlog(Blog blog) => BlogDAO.CreateBlog(blog);
        public void DeleteBlog(Blog b) => BlogDAO.DeleteBlog(b);

        public Blog GetBlogById(string id) => BlogDAO.GetBlogById(id);

        public Blog GetBlogByTitle(string title) => BlogDAO.GetBlogByTitle(title);

        public List<Blog> GetBlogs() => BlogDAO.GetBlogs();

        public void UpdateBlog(Blog blog) => BlogDAO.UpdateBlog(blog);
    }
}
