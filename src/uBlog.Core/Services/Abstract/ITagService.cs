using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface ITagService
    {
        Tag GetBySlug(string slug);
        List<Tag> GetAll();
    }
}