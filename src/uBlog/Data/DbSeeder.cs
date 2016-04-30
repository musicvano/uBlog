using System;
using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    public class DbSeeder
    {
        public static void Seed()
        {            
            using (var contex = new BlogContext())
            {
                contex.Database.EnsureDeleted();
                contex.Database.EnsureCreated();
                contex.Settings.Add(new Entities.Settings
                {
                    Title = "This is my blog",
                    PageSize= 10,
                    Author = "Ivan Muzyka",
                    Email = "musicvano@gmail.com",
                    Url = "mvano.com",
                    Phone = "+380960000000",
                    Company = "",
                    Location = "Ukraine",
                    Photo = "images/photo/my.jpg"
                });

                var tags = new List<Tag>
                {
                    new Tag
                    {
                        Name = "C#",
                        Slug = "csharp"
                    },
                    new Tag
                    {
                        Name = "ASP.NET",
                        Slug = "asp-net"
                    },
                    new Tag
                    {
                        Name = "C++",
                        Slug = "c++"
                    },
                    new Tag
                    {
                        Name = "Visual Studio",
                        Slug = "visual-studio"
                    },
                    new Tag
                    {
                        Name = "News",
                        Slug = "news"
                    }
                };

                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Text = "This awesome post"
                    },
                    new Comment
                    {
                        Text = "Hello from Admin"
                    },
                    new Comment
                    {
                        Text = "This is simple comment for testing"
                    },
                    new Comment
                    {
                        Text = "C++ is compileed programming language"
                    },
                    new Comment
                    {
                        Text = "Hi"
                    }
                };

                var posts = new List<Post>
                {
                    new Post
                    {
                        Title = "My first post",
                        Slug = "my-first-post",
                        Content = "This is my first post in this great blog. La-la-la...",
                        CreatedDate = new DateTime(2016, 4, 10),
                        PublishedDate = new DateTime(2016, 4, 10),
                        Published = true,
                        Comments = new List<Comment>
                        {
                            comments[0],
                            comments[1]
                        },
                        Tags = new List<Tag>
                        {
                            tags[4]
                        }
                    }
                };

                comments[0].Post = posts[0];
                //comments[0].PostId = 1;
                comments[1].Post = posts[0];
                //comments[1].PostId = 1;

                contex.Tags.AddRange(tags);
                contex.Comments.AddRange(comments);
                contex.Posts.AddRange(posts);

                contex.SaveChanges();
            }
        }
    }
}