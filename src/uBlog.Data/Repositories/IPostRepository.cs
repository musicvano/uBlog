using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public interface IPostRepository
    {
        Post Get(int id);
        Post GetBySlug(string slug);
        List<Post> GetAll();
        List<Post> GetByPage(int pageIndex, int pageSize);
    }
}