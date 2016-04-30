using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetByPage(int pageIndex, int pageSize);
    }
}