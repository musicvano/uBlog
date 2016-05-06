using Microsoft.Data.Entity;
using System.Linq;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context) { }

        public Post GetBySlug(string slug)
        {
            var post = context.Posts.Include(p => p.Comments).SingleOrDefault(p => string.Compare(p.Slug, slug, true) == 0);
            if (post != null)
            {
                post.PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == post.Id).ToList();
            }
            return post;
        }
    }
}