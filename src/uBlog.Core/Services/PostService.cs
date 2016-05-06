using System.Collections.Generic;
using uBlog.Core.Services;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    public class PostService : IPostService
    {
        IUnitOfWork uow;

        public PostService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Post> GetByPage(int page)
        {
            var settings = uow.Settings.SingleOrDefault(s => s.Id == 1);
            return uow.Posts.GetByPage(page, settings.PageSize);
        }

        public Post GetBySlug(string slug)
        {
            return uow.Posts.GetBySlug(slug);
        }
    }
}