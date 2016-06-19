using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IPostService
    {
        Post GetBySlug(string slug, bool encode = false);
        List<Post> GetByPage(int page, bool encode = false);
        int CountByTag(int tagId);
        List<Post> GetByTagSlug(string slug, int page);
    }
}
