using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IPostService
    {
        Post Get(int Id);
        Post GetBySlug(string slug, bool encode = false);
        List<Post> GetByPage(int page, bool encode = false);
        List<Post> GetAll();
        int CountByTag(int tagId);
        List<Post> GetByTagSlug(string slug, int page);
    }
}
