using FSK_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public interface IBlogService
    {
        List<Blog> GetBlogs();

        void CreateBlog(Blog blog);

        void DeleteBlog(Blog b);

        void UpdateBlog(Blog blog);

        Blog GetBlogByTitle(string title);

        Blog GetBlogById(string id);
    }
}
