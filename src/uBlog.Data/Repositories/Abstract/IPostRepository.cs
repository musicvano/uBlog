using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public interface IPostRepository: IRepository<Post>
    {
        int CountByTag(int tagId);
        List<Post> GetByTag(int tagId, int pageIndex, int pageSize);
        List<Post> GetByTagSlug(string tagSlug, int pageIndex, int pageSize);
        Post GetBySlug(string slug);
    }
}