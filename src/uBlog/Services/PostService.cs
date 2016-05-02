using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Services
{
    public class PostService : IPostService
    {
        BlogContext context;
        public PostService(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Post> GetByPage(int page)
        {
            var settings = context.Settings.Find(1);
            return context.Posts
                .OrderBy(p => p.PublishedDate)
                .Skip((page - 1) * settings.PageSize)
                .Take(settings.PageSize)
                .ToList();
        }

        public Post GetBySlug(string slug)
        {
            return context.Posts.Include(p => p.Comments).Include(p => p.PostTags).FirstOrDefault(p => String.Compare(p.Slug, slug, true) == 0);
        }
    }
}
