using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IPostService
    {
        Post GetBySlug(string slug);
        IList<Post> GetByPage(int page);
    }
}
