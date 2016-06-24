using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context) { }

        public new List<Post> GetAll()
        {
            return context.Posts.OrderBy(p => p.DateCreated).ToList();
        }

        public int CountByTag(int tagId)
        {
            return context.PostTags.Where(pt => pt.TagId == tagId).Count();            
        }

        public List<Post> GetByTag(int tagId, int pageIndex, int pageSize)
        {
            var posts = context.PostTags.Where(pt => pt.TagId == tagId)
                .Select(pt => pt.Post).OrderBy(p => p.DateCreated)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == posts[i].Id).ToList();
            }
            return posts;
        }

        public List<Post> GetByTagSlug(string tagSlug, int pageIndex, int pageSize)
        {
            var tag = context.Tags.SingleOrDefault(t => string.Compare(t.Slug, tagSlug, true) == 0);
            var res = tag != null ? GetByTag(tag.Id, pageIndex, pageSize) : new List<Post>();
            return res;
        }

        public new List<Post> GetByPage(int pageIndex, int pageSize)
        {
            var posts = context.Posts.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == posts[i].Id).ToList();
            }
            return posts;
        }

        public Post GetBySlug(string slug)
        {
            var post = context.Posts.SingleOrDefault(p => string.Compare(p.Slug, slug, true) == 0);
            if (post != null)
            {
                post.PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == post.Id).ToList();
            }
            return post;
        }
    }
}