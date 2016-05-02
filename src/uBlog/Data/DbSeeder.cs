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
                    Id = 1,
                    Title = "This is my blog",
                    PageSize = 10,
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
                        Id = 1,
                        Name = "News",
                        Slug = "news"
                    },
                    new Tag
                    {
                        Id = 2,
                        Name = "C#",
                        Slug = "csharp"
                    },
                    new Tag
                    {
                        Id = 3,
                        Name = "ASP.NET",
                        Slug = "asp-net"
                    },
                    new Tag
                    {
                        Id = 4,
                        Name = "C++",
                        Slug = "c++"
                    },
                    new Tag
                    {
                        Id = 5,
                        Name = "Visual Studio",
                        Slug = "visual-studio"
                    }
                };

                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        Text = "This awesome post"
                    },
                    new Comment
                    {
                        Id = 2,
                        Text = "Hello from Admin"
                    },
                    new Comment
                    {
                        Id = 3,
                        Text = "This is simple comment for testing"
                    },
                    new Comment
                    {
                        Id = 4,
                        Text = "C++ is compileed programming language"
                    },
                    new Comment
                    {
                        Id = 5,
                        Text = "Hi"
                    }
                };

                var posts = new List<Post>
                {
                    new Post
                    {
                        Id = 1,
                        Title = "Что такое блог",
                        Slug = "что-такое-блог",
                        Content = @"Блог (англ. blog, от web log — интернет-журнал событий, интернет-дневник, онлайн-дневник) — веб-сайт, основное содержимое которого
                        — регулярно добавляемые записи, содержащие текст, изображения или мультимедиа. Для блогов характерны недлинные записи вре́менной значимости, упорядоченные в обратном хронологическом порядке (последняя запись сверху). Отличия блога от традиционного дневника обусловливаются средой: блоги обычно публичны и предполагают сторонних читателей, которые могут вступить в публичную полемику с автором (в комментарии к блогозаписи или своих блогах).
Людей, ведущих блог, называют бло́герами. Совокупность всех блогов Сети принято называть блогосферой.
Для блогов характерна возможность публикации отзывов (комментариев) посетителями. Она делает блоги средой сетевого общения, имеющей ряд преимуществ перед электронной почтой, группами новостей, веб-форумами и чатами.
Под блогами также понимаются персональные сайты, которые состоят в основном из личных записей владельца блога и комментариев пользователей к этим записям.
Первым блогом считается страница Тима Бернерса-Ли, где он, начиная с 1992 г., публиковал новости. Более широкое рас­пространение блоги получили с 1996 г. В августе 1999 г. компью­терная компания Pyra Labs из Сан-Франциско открыла сайт Blogger.com, который стал первой бесплатной блоговой службой.
В настоящее время особенность блогов заключается не только в структуре записей, но и в простоте добавления новых записей. Пользователь просто обращается к веб-серверу, прохо­дит процесс идентификации пользователя, после чего он добавляет новую запись к своей коллекции. Сервер представляет инфор­мацию как последовательность сообщений, помещая в самом верху самые свежие сообщения. Структура коллекции напоми­нает привычную последовательную структуру дневника или журнала.",
                        CreatedDate = DateTime.Now,
                        PublishedDate = DateTime.Now,
                        //Published = true,
                        Comments = new List<Comment>
                        {
                            comments[0],
                            comments[1]
                        }/*,
                        PostTags = new List<PostTag>
                        {
                            new PostTag
                            {
                                Post
                                Tag = tags[0]
                            }
                        }*/
                    }/*,
                    new Post
                    {
                        Id = 2,
                        Title = "My first post",
                        Slug = "my-first-post",
                        Content = "This is my first post in this great blog. La-la-la...",
                        CreatedDate = DateTime.Now,
                        PublishedDate = DateTime.Now,
                        //Published = true,
                        Comments = new List<Comment>
                        {
                            comments[2],
                            comments[3]
                        },
                        PostTags = new List<PostTag>
                        {
                            new PostTag
                            {
                                Tag = tags[1]
                            },
                            new PostTag
                            {
                                Tag = tags[2]
                            }
                        }

                    }*/
                };

                var postTags = new List<PostTag>
                {
                    new PostTag
                    {
                        PostId = 1,
                        Post = posts[0],
                        TagId = 1,
                        Tag = tags[0]
                    }
                };
                //posts[0].PostTags = postTags;

                //comments[0].Post = posts[0];
                //comments[0].PostId = 1;
                //comments[1].Post = posts[0];
                //comments[1].PostId = 1;

                //contex.Tags.AddRange(tags);
                //contex.Comments.AddRange(comments);
                
                //contex.PostTags.AddRange(postTags);
                //posts[0].PostTags = postTags;
                //tags[0].PostTags = postTags;
                contex.Posts.AddRange(posts);
                contex.SaveChanges();
            }
        }
    }
}