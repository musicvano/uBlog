using System.Collections.Generic;
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
            return uow.Tags.GetBySlug(slug);
        }

        public List<Tag> GetAll()
        {
            return uow.Tags.GetAll();
        }
    }
}