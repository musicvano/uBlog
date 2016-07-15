using CommonMark;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class PostService : IPostService
    {
        IBlogContext context;

        private bool Contains(string source, string search)
        {
            return source != null && search != null && source.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
        }

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
            var posts = context.Posts.OrderBy(p => p.DateCreated).ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].PostTags = context.PostTags.Include(p => p.Tag).Where(p => p.PostId == posts[i].Id).ToList();
            }
            return posts;
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

        public List<Post> GetByText(string text)
        {
            var posts = GetAll();
            var resPosts = posts.Where(p =>
                Contains(p.Title, text) ||
                Contains(p.Content, text) ||
                p.PostTags.Any(pt => Contains(pt.Tag.Name, text))).ToList();
            return resPosts;
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