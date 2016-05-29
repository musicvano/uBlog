using CommonMark;
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

        public List<Post> GetByPage(int page, bool encode = false)
        {
            var settings = uow.Settings.SingleOrDefault(s => s.Id == 1);
            var posts = uow.Posts.GetByPage(page, settings.PageSize);
            if (encode)
            {
                for (int i = 0; i < posts.Count; i++)
                {
                    posts[i].Content = CommonMarkConverter.Convert(posts[i].Content);
                }
            }
            return posts;
        }

        public Post GetBySlug(string slug, bool encode = false)
        {
            var post = uow.Posts.GetBySlug(slug);
            if (encode && post != null)
            {
                post.Content = CommonMarkConverter.Convert(post.Content);
            }
            return post;
        }
    }
}