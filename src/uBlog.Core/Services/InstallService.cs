using System;
using System.Collections.Generic;
using uBlog.Core.Infrastructure;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class InstallService : IInstallService
    {
        private const string DefaultEmail = "admin@admin.com";
        private const string DefaultPassword = "admin";

        private readonly BlogContext context;

        public InstallService(IBlogContext context)
        {
            this.context = (BlogContext)context;
        }

        public bool RecreateDatabase()
        {
            return context.Database.EnsureCreated();
        }

        public void SeedDatabase()
        {
            var encriptionService = new EncryptionService();
            var salt = encriptionService.CreateSalt();
            var user = new User
            {
                Username = "User Name",
                Email = DefaultEmail,
                About = "Tell a little about yourself",
                Photo = "default.png",
                Url = "http://user.com",
                Github = "https://github.com/user",
                Facebook = "https://www.facebook.com/user",
                Twitter = "https://twitter.com/user",
                Skype = "user",
                Location = "Country",
                HashedPassword = encriptionService.EncryptPassword(DefaultPassword, salt),
                Salt = salt,
                DateCreated = DateTime.Now
            };
            context.Users.Add(user);

            var config = new Config
            {
                PageSize = 10,
                DisqusName = "admin"
            };
            context.Configs.Add(config);

            var tags = new List<Tag>
            {
                new Tag { Name = "News" },
                new Tag { Name = "C++" },
                new Tag { Name = "JS" }
            };
            tags.ForEach(tag => tag.Slug = UrlHelper.GetSlug(tag.Name));
            context.Tags.AddRange(tags);

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "About uBlog",
                    Content = article1,
                    DateCreated = DateTime.Now,
                    Draft = false
                },
                new Post
                {
                    Title = "Formating text in posts",
                    Content = article1,
                    DateCreated = DateTime.Now,
                    Draft = false
                }

            };
            posts.ForEach(post => post.Slug = UrlHelper.GetSlug(post.Title));
            context.Posts.AddRange(posts);

            var postTags = new List<PostTag> {
                new PostTag { Post = posts[0], Tag = tags[0] },
                new PostTag { Post = posts[1], Tag = tags[1] },
                new PostTag { Post = posts[1], Tag = tags[2] }
            };
            context.PostTags.AddRange(postTags);
            context.SaveChanges();
        }

        const string article1 = @"Text 1";

        const string article2 =@"Text 2";
    }
}