using System;
using System.Collections.Generic;
using uBlog.Core.Infrastructure;
using uBlog.Core.Services;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uTool
{
    public class DatabaseInitializer
    {
        private const string DefaultEmail = "admin@admin.com";
        private const string DefaultPassword = "admin";

        /// <summary>
        /// Creates new database
        /// </summary>
        public static void Create(string databasePath)
        {
            using (var context = new BlogContext(databasePath))
            {
                context.Database.EnsureCreated();
            }
        }

        /// <summary>
        /// Saves demo data to the database
        /// </summary>
        public static void Seed(string databasePath)
        {
            using (var context = new BlogContext(databasePath))
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
                    DomainUrl = "http://yourdomain.com",
                    PageSize = 10,
                    DisqusName = "admin",
                    AddThisId = "ra-0000000000000000",
                    GoogleId = "XX-00000000"
                };
                context.Configs.Add(config);

                var tags = new List<Tag>
            {
                new Tag { Name = "News" },
                new Tag { Name = "Markdown" }
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
                    Content = article2,
                    DateCreated = DateTime.Now,
                    Draft = false
                }

            };
                posts.ForEach(post => post.Slug = UrlHelper.GetSlug(post.Title));
                context.Posts.AddRange(posts);

                var postTags = new List<PostTag> {
                new PostTag { Post = posts[0], Tag = tags[0] },
                new PostTag { Post = posts[1], Tag = tags[1] }
            };
                context.PostTags.AddRange(postTags);
                context.SaveChanges();

            };
        }

        const string article1 =
@"Hi! I am excited to present this simple blog engine **uBlog**.

![Logo](/images/logo.png)

uBlog differs from WordPress greatly. First of all uBlog is personal blog, so only
one author can write posts and have access to admin panel. uBlog uses markdown syntax
instead of rich text editors. Nevertheless don't worry
about it. Markdow is extreamly simple so after three-four written posts you will
compose your stories fluently. Take a look at [Markdown Reference](http://commonmark.org/help).

> Markdown is a simple way to format text that looks great on any device.
It doesn’t do anything fancy like change the font size, color, or type —
just the essentials, using keyboard symbols you already know.

Credentials for admin panel:
- E-mail: **admin@admin.com**
- Password: **admin**

uBlog uses [Disqus](https://disqus.com) for commenting and [AddThis](https://www.addthis.com)
for sharing posts across social networks. So you have to create accounts
there and register your website.

More information about database managment, backuping, SEO will be available soon on 
[Wiki](https://github.com/musicvano/uBlog/wiki).
If you have some suggestions and recommendations feel free to [contact me](http://mvano.com/about).
";

        const string article2 =
@"
You can insert programming code into posts and it will be highlighted appropriately.

```c
int main()
{
    printf(""Hello World"");
    return 0;
}
```
";
    }
}