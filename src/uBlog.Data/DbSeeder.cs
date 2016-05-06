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
                var setting = new Settings
                {
                    Title = "This is my blog",
                    PageSize = 10,
                    Author = "Ivan Muzyka",
                    Email = "musicvano@gmail.com",
                    Url = "mvano.com",
                    Phone = "+380960000000",
                    Company = "",
                    Location = "Ukraine",
                    Photo = "images/photo/my.jpg"
                };
                contex.Settings.Add(setting);

                var tags = new List<Tag>
                {
                    new Tag
                    {
                        Name = "News",
                        Slug = "news"
                    },
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
                    }
                };
                contex.Tags.AddRange(tags);

                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Text = "This awesome post",
                        DateCreated = DateTime.Now
                    },
                    new Comment
                    {
                        Text = "Hello from Admin",
                        DateCreated = DateTime.Now
                    },
                    new Comment
                    {
                        Text = "This is simple comment for testing",
                        DateCreated = DateTime.Now
                    },
                    new Comment
                    {
                        Text = "C++ is compiled programming language",
                        DateCreated = DateTime.Now
                    },
                    new Comment
                    {
                        Text = "Hi",
                        DateCreated = DateTime.Now
                    }
                };
                contex.Comments.AddRange(comments);

                var posts = new List<Post>
                {
                    new Post
                    {
                        Title = "Что такое блог",
                        Slug = "что-такое-блог",
                        Content = @"Блог (англ. blog, от web log — интернет-журнал событий, интернет-дневник, онлайн-дневник) — веб-сайт, основное содержимое которого
                        — регулярно добавляемые записи, содержащие текст, изображения или мультимедиа. Для блогов характерны недлинные записи вре́менной значимости,
                        упорядоченные в обратном хронологическом порядке (последняя запись сверху). Отличия блога от традиционного дневника обусловливаются средой:
                        блоги обычно публичны и предполагают сторонних читателей, которые могут вступить в публичную полемику с автором (в комментарии к блогозаписи или своих блогах).
                        Людей, ведущих блог, называют бло́герами. Совокупность всех блогов Сети принято называть блогосферой.
                        Для блогов характерна возможность публикации отзывов (комментариев) посетителями. Она делает блоги средой сетевого общения, имеющей ряд преимуществ перед электронной почтой, группами новостей, веб-форумами и чатами.
                        Под блогами также понимаются персональные сайты, которые состоят в основном из личных записей владельца блога и комментариев пользователей к этим записям.
                        Первым блогом считается страница Тима Бернерса-Ли, где он, начиная с 1992 г., публиковал новости. Более широкое рас­пространение блоги получили с 1996 г.
                        В августе 1999 г. компью­терная компания Pyra Labs из Сан-Франциско открыла сайт Blogger.com, который стал первой бесплатной блоговой службой.
                        В настоящее время особенность блогов заключается не только в структуре записей, но и в простоте добавления новых записей.
                        Пользователь просто обращается к веб-серверу, прохо­дит процесс идентификации пользователя, после чего он добавляет новую запись к своей коллекции. Сервер представляет инфор­мацию как последовательность сообщений, помещая в самом верху самые свежие сообщения. Структура коллекции напоми­нает привычную последовательную структуру дневника или журнала.",
                        DateCreated = DateTime.Now,
                        Draft = false,
                        Comments = new List<Comment>
                        {
                            comments[0],
                            comments[1]
                        }
                    },
                    new Post
                    {
                        Title = "My first post",
                        Slug = "my-first-post",
                        Content = "This is my first post in this great blog. La-la-la...",
                        DateCreated = DateTime.Now,
                        Draft = false,
                        Comments = new List<Comment>
                        {
                            comments[2],
                            comments[3],
                            comments[4]
                        }
                    }
                };
                contex.Posts.AddRange(posts);

                var postTags = new List<PostTag>
                {
                    new PostTag
                    {
                        Post = posts[0],
                        Tag = tags[0]
                    },
                    new PostTag
                    {
                        Post = posts[1],
                        Tag = tags[1]
                    },
                    new PostTag
                    {
                        Post = posts[1],
                        Tag = tags[2]
                    }
                };
                contex.PostTags.AddRange(postTags);
                contex.SaveChanges();
            }
        }
    }
}