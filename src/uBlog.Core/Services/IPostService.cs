using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IPostService
    {
        Post GetBySlug(string slug);
        List<Post> GetByPage(int page);
    }
}
