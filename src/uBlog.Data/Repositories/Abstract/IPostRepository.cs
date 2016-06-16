using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public interface IPostRepository: IRepository<Post>
    {
        Post GetBySlug(string slug);
        int CountByTagId(int tagId);
    }
}