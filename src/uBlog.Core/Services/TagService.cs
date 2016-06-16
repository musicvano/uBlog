using System.Collections.Generic;
using System.Linq;
using uBlog.Core.Models;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class TagService : ITagService
    {
        IUnitOfWork uow;

        public TagService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Tag GetBySlug(string slug)
        {
            return null;
        }

        public int CountPostByTagId(int id)
        {
            return uow.Posts.CountByTagId(id);
        }

        public List<TagModel> GetAll()
        {
            var tags = uow.Tags.GetAll();
            var tagModels = tags.Select(t => new TagModel()
            {
                Name = t.Name,
                Slug = t.Slug
            }).OrderBy(t => t.Name).ToList();
            foreach (var tag in tagModels)
            {
                tag.PostCount = 24;
            }
            return tagModels;
        }
    }
}