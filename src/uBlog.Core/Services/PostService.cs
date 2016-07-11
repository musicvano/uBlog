using CommonMark;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class PostService : IPostService
    {
        IBlogContext context;

        public PostService(IBlogContext context)
        {
            this.context = context;
        }

        public Post Get(int Id)
        {
            return context.Posts.SingleOrDefault(p => p.Id == Id);
        }

        public List<Post> GetAll()
        {
            return context.Posts.ToList();
        }

        public List<Post> GetByPage(int page, int pageSize)
        {
            var posts = context.Posts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == posts[i].Id).ToList();
            }
            return posts;
        }

        public Post GetBySlug(string slug)
        {
            slug = slug.ToLower();
            var post = context.Posts.SingleOrDefault(p => p.Slug == slug);
            if (post != null)
            {
                post.PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == post.Id).ToList();
            }
            return post;
        }

        public List<Post> GetByTag(int tagId, int page, int pageSize)
        {
            var posts = context.PostTags.Where(pt => pt.TagId == tagId)
                .Select(pt => pt.Post).OrderBy(p => p.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == posts[i].Id).ToList();
            }
            return posts;
        }

        public void EncodeContent(Post post)
        {
            post.Content = CommonMarkConverter.Convert(post.Content);
        }

        public void EncodeContent(ICollection<Post> posts)
        {
            foreach (var post in posts)
            {
                post.Content = CommonMarkConverter.Convert(post.Content);
            }
        }

    }
}