using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IPostService
    {
        Post Get(int Id);
        List<Post> GetAll();
        Post GetBySlug(string slug);
        List<Post> GetByPage(int page, int pageSize);
        List<Post> GetByTag(int tagId, int page, int pageSize);
        void EncodeContent(Post post);
        void EncodeContent(ICollection<Post> posts);
    }
}
