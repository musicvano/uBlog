using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Services
{
    public interface IPostService
    {
        Post GetBySlug(string slug);
        IEnumerable<Post> GetByPage(int page);
    }
}
