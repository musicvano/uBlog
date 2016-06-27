using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        public new List<Tag> GetAll()
        {
            var tags = context.Set<Tag>().OrderBy(t => t.Name).ToList();
            for (int i = 0; i < tags.Count; i++)
            {
                tags[i].PostTags = context.PostTags.Include(p => p.Post).Where(p => p.TagId == tags[i].Id).ToList();
            }
            return tags;
        }

        public Tag GetBySlug(string slug)
        {
            return context.Tags.SingleOrDefault(t => string.Compare(t.Slug, slug, true) == 0);
        }
    }
}