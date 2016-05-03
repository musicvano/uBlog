using System.Collections.Generic;
using uBlog.Core.Services;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    public class PostService : IPostService
    {
        private IBlogContext context;

        public PostService(IBlogContext context)
        {
            this.context = context;
        }

        public IList<Post> GetByPage(int page)
        {
            return context.Posts.GetByPage(page, 10);
        }

        public Post GetBySlug(string slug)
        {
            return context.Posts.GetBySlug(slug);
        }
    }
}