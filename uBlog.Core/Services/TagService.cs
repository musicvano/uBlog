using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class TagService : ITagService
    {
        IBlogContext context;

        public TagService(IBlogContext context)
        {
            this.context = context;
        }

        public Tag GetBySlug(string slug)
        {
            slug = slug.ToLower();
            var tag = context.Tags.SingleOrDefault(t => t.Slug == slug);
            return tag;
        }

        public List<Tag> GetAll()
        {
            var tags = context.Tags.OrderBy(t => t.Name).ToList();
            for (int i = 0; i < tags.Count; i++)
            {
                tags[i].PostTags = context.PostTags.Include(p => p.Post).Where(p => p.TagId == tags[i].Id).ToList();
            }
            return tags;
        }
    }
}