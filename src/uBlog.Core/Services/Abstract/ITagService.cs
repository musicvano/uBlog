using System.Collections.Generic;
using uBlog.Core.Models;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface ITagService
    {
        List<TagModel> GetAll();
    }
}