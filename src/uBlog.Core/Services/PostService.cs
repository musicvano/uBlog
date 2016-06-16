using CommonMark;
using System.Collections.Generic;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
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
            var config = uow.Configs.SingleOrDefault(s => s.Id == 1);
            var posts = uow.Posts.GetByPage(page, config.PageSize);
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