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
            return context.Set<Tag>().OrderBy(t => t.Name).ToList();
        }

        public Tag GetBySlug(string slug)
        {
            return context.Tags.SingleOrDefault(t => string.Compare(t.Slug, slug, true) == 0);
        }
    }
}