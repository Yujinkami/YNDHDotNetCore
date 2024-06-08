using Microsoft.EntityFrameworkCore;
using YNDHDotNetCore.RestApiWithNLayer.Models;
using YNDHDotNetCore.NLayer.DataAccess.Services;

namespace YNDHDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dablog;

        public BL_Blog()
        {
            _dablog = new DA_Blog();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _dablog.GetBlogs();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _dablog.GetBlog(id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var result = _dablog.CreateBlog(requestModel);
            return result;
        }

        public int UpadteBlog(int id, BlogModel requestModel)
        {
            var result = _dablog.UpadteBlog(id, requestModel);
            return result;
        }

        public int DeleteBlog(int id)
        {           
            var result = _dablog.DeleteBlog(id);
            return result;
        }
    }
}
