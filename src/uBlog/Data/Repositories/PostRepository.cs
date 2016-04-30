using System.Collections.Generic;
using System.Linq;
using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context)
        {
        }

        public IEnumerable<Post> GetByPage(int pageIndex, int pageSize)
        {
            return BlogContext.Posts
                .OrderBy(p => p.PublishedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}