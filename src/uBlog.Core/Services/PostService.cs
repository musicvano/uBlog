using CommonMark;
using System.Collections.Generic;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class PostService : IPostService
    {
        IUnitOfWork uow;
        Settings settings;

        private void MarkConvert(Post post)
        {
            post.Content = CommonMarkConverter.Convert(post.Content);
        }

        private void MarkConvert(List<Post> posts)
        {
            foreach (var post in posts)
            {
                MarkConvert(post);
            }
        }

        public PostService(IUnitOfWork uow)
        {
            this.uow = uow;
            settings = uow.Settings.SingleOrDefault(s => s.Id == 1);
        }

        public Post Get(int Id)
        {
            return uow.Posts.Get(Id);
        }

        public List<Post> GetAll()
        {
            return uow.Posts.GetAll();
        }

        public List<Post> GetByPage(int page, bool encode = false)
        {
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
                MarkConvert(post);
            }
            return post;
        }

        public int CountByTag(int tagId)
        {
            return uow.Posts.CountByTag(tagId);
        }

        public List<Post> GetByTagSlug(string slug, int page)
        {
            var posts =  uow.Posts.GetByTagSlug(slug, page, settings.PageSize);
            MarkConvert(posts);
            return posts;
        }
    }
}