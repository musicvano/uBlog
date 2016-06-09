using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context) { }

        public new List<Post> GetByPage(int pageIndex, int pageSize)
        {
            var posts = context.Posts.Include(p => p.Comments).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == posts[i].Id).ToList();
            }
            return posts;
        }

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